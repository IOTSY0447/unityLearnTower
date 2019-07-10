using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttle : MonoBehaviour {
    private GameObject targetEnemy;
    public float speed = 100;
    public Vector3 speed3 = new Vector3 (0, 0.5f, 0);
    public Vector3 a = new Vector3 (0, 0, 0);
    public float tADelay = 0.05f;
    private float tAVal = 0;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (!targetEnemy) {
            Debug.LogError ("没有目标");
        }
        if (!targetEnemy.activeInHierarchy) {
            Global.GetButtlePool.PushObject (gameObject);
            // Debug.LogError ("目标超出界面");
        }
        moveAnction ();
        checkIsTouch ();
    }
    void moveAnction () {
        // transform.position = Vector3.MoveTowards (transform.position, targetEnemy.transform.position, speed);
        float t = Time.deltaTime * 2f;
        tAVal += Time.deltaTime * 2;
        a = Vector3.Normalize (targetEnemy.transform.position - transform.position);
        if (tAVal < 1) {
            a *= tAVal;
        }
        Vector3 s = (speed3 * t + a * 0.5f * t * t * speed) * 0.05f;
        transform.position += s;
    }
    void checkIsTouch () {
        float dis = Vector3.Distance (transform.position, targetEnemy.transform.position);
        if (dis < 0.5f) {
            onTouchEnemy ();
        }
    }
    public void addTarget (GameObject obj) {
        targetEnemy = obj;
    }
    void onTouchEnemy () {
        tAVal = 0;
        Global.GetButtlePool.PushObject (gameObject);
    }
}