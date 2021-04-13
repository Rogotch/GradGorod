using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    public MonoBehaviour ObjectScript;

    public void CreateObject()
    {

        GameObject newObject = Instantiate(new GameObject());
        newObject.transform.SetParent(gameObject.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
