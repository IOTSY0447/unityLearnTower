using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour {
    public GameObject buildMenu;
    private GameObject targetTowerObj;
    public GameObject updateMenu;
    void Start () {
        Global.GetInstance.GetEvent ().AddListener (ProgressEvent);
    }

    void Update () {

    }
    void ProgressEvent (EventEnum eventType, GameObject obj) {
        switch (eventType) {
            case EventEnum.BuildMenu:
                updateMenu.SetActive (false);
                ShowBuildMenu (obj);
                targetTowerObj = obj;
                break;
            case EventEnum.showUpdateMenu:
                buildMenu.SetActive (false);
                ShowUpdateMenu (obj);
                targetTowerObj = obj;
                break;
        }
    }
    void ShowBuildMenu (GameObject obj) {
        buildMenu.SetActive (true);
        buildMenu.transform.position = Camera.main.WorldToScreenPoint (obj.transform.position);
    }
    public void CilckEvent (string data) {
        switch (data) {
            case "tower1":
                Global.GetInstance.GetEvent ().Invoke (EventEnum.tower1, targetTowerObj);
                buildMenu.SetActive (false);
                break;
            case "tower2":
                Global.GetInstance.GetEvent ().Invoke (EventEnum.tower2, targetTowerObj);
                buildMenu.SetActive (false);
                break;
            case "sell":
                Destroy (targetTowerObj);
                updateMenu.SetActive (false);
                break;
            case "update":
                targetTowerObj.transform.GetComponent<Tower> ().UpdateTower ();
                updateMenu.SetActive (false);
                break;
        }
    }
    void ShowUpdateMenu (GameObject obj) {
        updateMenu.SetActive (true);
        int level = obj.transform.GetComponent<Tower> ().towerLevel;
        bool isShow = level < obj.transform.GetComponent<Tower> ().levelColorst.Length - 1;
        updateMenu.transform.Find ("update").gameObject.SetActive (isShow);
        updateMenu.transform.position = Camera.main.WorldToScreenPoint (obj.transform.position);
    }
}