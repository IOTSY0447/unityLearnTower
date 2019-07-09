using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {
    public List<GameObject> towerPrefabList;
    void Start () {
        Global.GetInstance.GetEvent ().AddListener (ProcessEvent);
    }
    void Update () {

    }
    void ProcessEvent (EventEnum eventType, GameObject obj) {
        switch (eventType) {
            case EventEnum.tower1:
                BuildTower (towerPrefabList[0], obj);
                break;
            case EventEnum.tower2:
                BuildTower (towerPrefabList[1], obj);
                break;
        }
    }
    void BuildTower (GameObject obj, GameObject tb) {
        GameObject tower = Instantiate (obj, tb.transform.position, Quaternion.identity);
        tower.transform.parent = transform;
    }
}