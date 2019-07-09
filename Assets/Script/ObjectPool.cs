using System.Collections.Generic;
using UnityEngine;

public class ObjectPool {
    private List<GameObject> objectList = new List<GameObject> ();
    public ObjectPool () {

    }
    public GameObject GetObject () {
        GameObject enemy;
        if (objectList.Count > 0) {
            enemy = objectList[objectList.Count - 1];
            objectList.RemoveAt (objectList.Count - 1);
            return enemy;
        }
        return null;
    }
    public void PushObject (GameObject obj) {
        obj.SetActive (false);
        objectList.Add (obj);
    }
}