using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.AllResources;
using Assets.Scripts.ENUMs;
using UnityEngine;
using UnityEngine.UI;

public class ResPanel : MonoBehaviour, ISVItem
{
    public BuildingPanel InfoBuilding;
    public Building SelectedBuilding;
    public GameObject Res;
    public Image Icon;
    public Text Value;
    public CityResource selectedRes;
    public bool CheckingTheCondition()
    {
        CityResource resource = Res.GetComponent<GlobalResource>().Resource;
        for (int i = 0; i < SelectedBuilding.ResourceModifiers.Count; i++)
        {
            if (SelectedBuilding.ResourceModifiers[i].Resource == resource.Resource)
            {
                selectedRes = SelectedBuilding.ResourceModifiers[i];
                return true;
            }
        }

        return false;
    }

    public void SetSelectedObject(GameObject obj)
    {
        Res = obj;
    }

    public void UpdateParameters()
    {
        SelectedBuilding = InfoBuilding.SelectedBuildingObject;
        Icon.sprite = Res.GetComponent<GlobalResource>().ResourceIcon;
        Value.text = "x" + selectedRes.Value;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
