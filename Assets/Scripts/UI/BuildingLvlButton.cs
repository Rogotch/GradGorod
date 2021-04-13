using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.GlobalScripts;
using UnityEngine;

public class BuildingLvlButton : MonoBehaviour
{
    public BuildingPanel InfoPanel;
    public GlobalScript MainScriptObj;
    public int Level;
    public GameObject Image;
    public GameObject Latch;

    // Start is called before the first frame update

    public void MouseClack()
    {
        InfoPanel.SelectedBuildingObject = MainScriptObj.AllBuildings[Level - 1];
        InfoPanel.SelectedLevel = Level;
        InfoPanel.UpdateParameters();
        Latch.transform.position = new Vector3(Image.transform.position.x, Latch.transform.position.y, Latch.transform.position.z);
    }

}
