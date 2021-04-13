using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.AllResources;
using Assets.Scripts.ENUMs;
using Assets.Scripts.GlobalScripts;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePanel : MonoBehaviour, ISVItem
{
    public GameObject SelectedObject;
    public GameObject inCome;
    public GameObject Icon;
    public GameObject TexGameObject;
    private VisitResources ResourceType;

    // Start is called before the first frame update
    void Start()
    {
        UpdateParameters();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TexGameObject.GetComponent<Text>().text =
            "" + Math.Round(inCome.GetComponent<GlobalScript>().PlayerResources[ResourceType].Value, 1);
    }

    public void SetSelectedObject(GameObject obj)
    {
        SelectedObject = obj;
    }

    public void UpdateParameters()
    {
        Icon.GetComponent<Image>().sprite = SelectedObject.GetComponent<GradResource>().Icon;
        Icon.GetComponent<Image>().color = SelectedObject.GetComponent<GradResource>().IconColor;
        ResourceType = SelectedObject.GetComponent<GradResource>().Resource;
    }

    public bool CheckingTheCondition()
    {
        return true;
    }
}
