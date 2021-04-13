using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Buildings;
using Assets.Scripts.GlobalScripts;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GlobalScript MainScriptObj;
    public GameObject[] BuildingGroups = new GameObject[5];
    public BuildingPanel InfoPanel;

    public int lvl;
   //public List<Building>
    // Start is called before the first frame update

    public void BuildConstruction()
    {
        if (!MainScriptObj.LockRemove[lvl-1])
        {
            BuildingsStack construction = new BuildingsStack(BuildingGroups[lvl - 1], MainScriptObj.Conditions);
            MainScriptObj.AllBuildings[lvl - 1] = construction.ResultConstruction;
            MainScriptObj.UpdateImg();
            InfoPanel.SelectedBuildingObject = MainScriptObj.AllBuildings[InfoPanel.SelectedLevel - 1];
            InfoPanel.UpdateParameters();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
