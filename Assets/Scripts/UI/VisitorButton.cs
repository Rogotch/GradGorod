using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Flags;
using Assets.Scripts.GlobalScripts;
using UnityEngine;
using UnityEngine.UI;

public class VisitorButton : MonoBehaviour, ISVItem
{
    public GameObject VisitorObject;
    public GameObject Name;
    public GameObject Icon;
    public GameObject Description;
    public GameObject SelectedVisitorsObjects;

    // Start is called before the first frame update
    void Start()
    {
        UpdateParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateParameters()
    {
        Name.GetComponent<Text>().text = VisitorObject.GetComponent<Visitor>().Name;
        Description.GetComponent<Text>().text = VisitorObject.GetComponent<Visitor>().Description;
        Icon.GetComponent<Image>().sprite = VisitorObject.GetComponent<Visitor>().Icon;
    }

    public void SetSelectedObject(GameObject obj)
    {
        VisitorObject = obj;
    }

    public bool CheckingTheCondition()
    {
        List<Flag> visitorConditions = VisitorObject.GetComponent<Visitor>().AllUnitConditions;
        AllConditions conditions = SelectedVisitorsObjects.GetComponent<GlobalScript>().Conditions;
        return conditions.CheckListConditions(visitorConditions);
    }
}
