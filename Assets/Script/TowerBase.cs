﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        transform.GetComponent<MeshRenderer>().material.color = Color.yellow;
        Global.GetInstance.GetEvent().Invoke(EventEnum.BuildMenu,gameObject);
    }
    private void OnMouseUp() {
        transform.GetComponent<MeshRenderer>().material.color = Color.white;
    }
}
