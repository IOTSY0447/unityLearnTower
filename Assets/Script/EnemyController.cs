using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject pathObject;
    public float addEnemyCurrentTime = 0.5f;
    private float addEnemyVal = 0;
    private ObjectPool enemyPool = new ObjectPool ();
    public List<GameObject> enemyList = new List<GameObject> (); //存活的

    void Awake() {
        Global.EnemyController = this;
    }
    void Start () { }
    GameObject CreatorEnemy () {
        GameObject enemy = Instantiate (enemyPrefab);
        enemy.transform.parent = transform;
        enemy.transform.GetComponent<Enemy> ().SetObjectPool (enemyPool);
        return enemy;
    }
    void Update () {
        if (addEnemyVal >= addEnemyCurrentTime) {
            addEnemyVal = 0;
            AddEnemy ();
        }
        addEnemyVal += Time.deltaTime;

    }
    void AddEnemy () {
        GameObject enemy = enemyPool.GetObject ();
        if (!enemy) {
            enemy = CreatorEnemy ();
        }
        enemy.SetActive (true);
        enemy.transform.position = pathObject.transform.GetChild (0).transform.position;
        enemy.transform.GetComponent<Enemy> ().InitWithData (pathObject, gameObject);
        enemyList.Add (enemy);
    }
    public void EnemyEnd (GameObject enemy) {
        enemyList.Remove (enemy);
    }
}