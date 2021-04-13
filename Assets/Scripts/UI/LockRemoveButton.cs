using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GlobalScripts;
using UnityEngine;
using UnityEngine.UI;

public class LockRemoveButton : MonoBehaviour
{
    public GlobalScript MainScriptObj;
    public BuildingPanel InfoPanel;


    public void UpdateParams()
    {
        gameObject.GetComponent<Toggle>().isOn = MainScriptObj.LockRemove[InfoPanel.SelectedLevel - 1];
    }

    public void MouseClick()
    {
        MainScriptObj.LockRemove[InfoPanel.SelectedLevel - 1] = gameObject.GetComponent<Toggle>().isOn;
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateParams();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
