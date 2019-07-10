using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    public GameObject body;
    public GameObject attackRangPrefab;
    private GameObject attackRangNode;
    private Color beforeColor;
    public GameObject buttlePosition;
    public GameObject buttlePrefab;
    public float buttleDisTime = 0.2f;
    private float buttleTimeVal = 0;
    public int towerLevel = 0;
    public Color[] levelColorst = {
        Color.blue,
        Color.green,
        Color.red,
        Color.cyan
    };
    public float rangBaseNum = 5;
    private GameObject targetEnemy = null;
    void Start () {
        RefreshColor ();
    }

    // Update is called once per frame
    void Update () {
        List<GameObject> eList = Global.EnemyController.enemyList;
        double rang = getRang ();
        if (!targetEnemy || Vector3.Distance (targetEnemy.transform.position, transform.position) > rang) {
            targetEnemy = eList.Find ((obj) => {
                float dis = Vector3.Distance (obj.transform.position, transform.position);
                return dis <= rang;
            });
        }
        buttleTimeVal += Time.deltaTime;
        if (targetEnemy) {
            Vector3 temp = targetEnemy.transform.position - transform.position;
            temp.y = 0;
            Quaternion target = Quaternion.LookRotation (temp);
            transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 5); //插值的缓慢旋转
            // transform.rotation = target;//很僵硬的旋转
            if (buttleTimeVal >= buttleDisTime) {
                addButtle ();
                buttleTimeVal = 0;
            }
        }
    }
    public double getRang () {
        return (rangBaseNum + 0.1f * towerLevel * rangBaseNum);
    }
    private void OnMouseDown () {
        body.transform.GetComponent<MeshRenderer> ().material.color = Color.yellow;
        Global.GetInstance.GetEvent ().Invoke (EventEnum.showUpdateMenu, gameObject);
        showRang ();
    }
    private void OnMouseUp () {
        body.transform.GetComponent<MeshRenderer> ().material.color = beforeColor;
    }
    public void UpdateTower () {
        towerLevel++;
        RefreshColor ();
        showRang ();
    }
    void RefreshColor () {
        beforeColor = body.transform.GetComponent<MeshRenderer> ().material.color = levelColorst[towerLevel];
    }
    void showRang () {
        if (!attackRangNode) {
            attackRangNode = Instantiate (attackRangPrefab);
            attackRangNode.transform.parent = transform;
            float D = (1.1f - transform.position.y) / transform.localScale.y; //1.1刚好比路高0.1
            attackRangNode.transform.localPosition = new Vector3 (0, D, 0);
        }
        attackRangNode.SetActive (true);
        float rangF = (float) getRang () * 1.28f * 2;
        attackRangNode.transform.localScale = new Vector3 (rangF, rangF, rangF);
    }
    void addButtle () {
        GameObject buttleOne = Global.GetButtlePool.GetObject ();
        if (!buttleOne) {
            buttleOne = Instantiate (buttlePrefab);
            Global.GetButtlePool.PushObject (buttleOne);
            buttleOne.transform.parent = transform.parent;
        }
        buttleOne.transform.position = buttlePosition.transform.position;
        buttleOne.SetActive (true);
        buttleOne.GetComponent<buttle>().addTarget(targetEnemy);
    }

}