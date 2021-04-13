using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.GlobalScripts;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    public Building SelectedBuildingObject;

    public Text Name;
    public Text Description;
    public Text ExtensionsCount;
    public GameObject Resources;
    public GameObject Extensions;
    public LockRemoveButton ToggleLock;
    public int SelectedLevel = 1;

    public GlobalScript MainScriptObj;

    public void UpdateParameters()
    {
        Extensions.GetComponent<ScrollExtensionView>().BuildingSource = SelectedBuildingObject;
        Name.text = SelectedBuildingObject.Name;
        Description.text = SelectedBuildingObject.Description;
        ExtensionsCount.text = SelectedBuildingObject.Extensions.Count + "/" + SelectedBuildingObject.ExtensionLimit;
        Extensions.GetComponent<ScrollExtensionView>().AddAllItems();
        Resources.GetComponent<ScrollView>().AddAllItems();
        ToggleLock.UpdateParams();
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
