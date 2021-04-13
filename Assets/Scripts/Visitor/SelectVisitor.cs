using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GlobalScripts;
using UnityEngine;

public class SelectVisitor : MonoBehaviour
{
    public GameObject SelectedVis;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void MouseClick()
    {
        GameObject unit = GetComponent<VisitorButton>().VisitorObject;
        int lvl = unit.GetComponent<Visitor>().Level;
        SelectedVis.GetComponent<GlobalScript>().ChangeVisitor(unit.GetComponent<Visitor>(), lvl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
