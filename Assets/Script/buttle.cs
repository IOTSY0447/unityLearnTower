using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttle : MonoBehaviour {
    private GameObject targetEnemy;
    public float speed = 0.3f;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (!targetEnemy) {
            Debug.LogError ("没有目标");
        }
        if(!targetEnemy.activeInHierarchy){
            Global.GetButtlePool.PushObject (gameObject);
            // Debug.LogError ("目标超出界面");
        }
        transform.position  = Vector3.MoveTowards (transform.position, targetEnemy.transform.position, speed);
        float dis = Vector3.Distance (transform.position, targetEnemy.transform.position);
        if (dis < 0.1f) {
            onTouchEnemy ();
        }
    }
    public void addTarget (GameObject obj) {
        targetEnemy = obj;
    }
    void onTouchEnemy () {
        Global.GetButtlePool.PushObject (gameObject);
    }
}