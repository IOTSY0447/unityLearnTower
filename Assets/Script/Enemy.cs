using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Start is called before the first frame update
    private List<Vector3> pathList = new List<Vector3> ();
    private Vector3 targetPos = Vector3.zero;
    private int pathIndex = 0;
    private ObjectPool enemyPool = null;
    private GameObject enemyControl = null;
    public float speed = 0.2f;
    void Start () {

    }
    public void SetObjectPool (ObjectPool pool) {
        enemyPool = pool;
    }

    // Update is called once per frame
    void Update () {
        if (pathList.Count != 0 && targetPos.Equals (Vector3.zero) && pathIndex < pathList.Count) {
            targetPos = pathList[pathIndex];
        }
        if (!targetPos.Equals (Vector3.zero)) {
            transform.position = Vector3.MoveTowards (transform.position, targetPos, speed);
            float distance = Vector3.Distance (transform.position, targetPos);
            if (distance < 0.1f) {
                pathIndex++;
                targetPos = Vector3.zero;
                if (pathIndex == pathList.Count) {
                    enemyPool.PushObject (gameObject);
                    enemyControl.transform.GetComponent<EnemyController> ().EnemyEnd (gameObject);
                }
            }
        }
    }
    public void InitWithData (GameObject path, GameObject control) {
        enemyControl = control;
        for (int i = 0; i < path.transform.childCount; i++) {
            pathList.Add (path.transform.GetChild (i).transform.position);
        }
    }
}