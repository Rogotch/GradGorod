using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.PopulationFolder;
using Assets.Scripts.UI;
using UnityEngine;

public class ScrollViewPopulation : MonoBehaviour
{
    public Population PopulationObject;
    public GameObject Content;
    public PanelPopulationElement Item;
    public bool RaceFlag;

    public void InformationList()
    {
        DestroyAllChild(Content);
        PopulationObject.SortLists();
        var listSpecializations = PopulationObject.AllSpecialization;
        if (RaceFlag)
            InstRaces();
        else
            InstSpecializations();
    }

    private void InstRaces()
    {
        var listRaces = PopulationObject.AllRaces;
        foreach (var race in listRaces)
        {
            if (!race.CheckCondition())
                continue;
            var infoPanel = Instantiate(Item);
            infoPanel.Category = race;
            infoPanel.UpdatePanel(race.CategoryColor, race.PercentSize, race.GetStringName());
            infoPanel.transform.SetParent(Content.transform);
            infoPanel.transform.localScale = Vector3.one;
        }
    }
    private void InstSpecializations()
    {
        var listSpecialization = PopulationObject.AllSpecialization;
        foreach (var specialization in listSpecialization)
        {
            if (!specialization.CheckCondition())
                continue;
            var infoPanel = Instantiate(Item);
            infoPanel.Category = specialization;
            infoPanel.UpdatePanel(specialization.CategoryColor, specialization.PercentSize, specialization.GetStringName());
            infoPanel.transform.SetParent(Content.transform);
            infoPanel.transform.localScale = Vector3.one;
        }
    }
    public void CheckCategories()
    {
        List<PopulationCategory> listCategory 
            = PopulationObject.GetCategoryList(RaceFlag);
        if (CheckCount()) UpdateInfo();
        else InformationList();
    }

    public void UpdateInfo()
    {
        PopulationObject.SortLists();
        List<PopulationCategory> listCategory = PopulationObject.GetCategoryList(RaceFlag);
        List<GameObject> children = new List<GameObject>();
        GetAllChildren(Content, ref children);
        for (int i = 0; i < children.Count; i++)
        {
            if (RaceFlag)
                children[i].GetComponent<PanelPopulationElement>().Name.text = PopulationObject.AllRaces[i].GetStringName();
            else
                children[i].GetComponent<PanelPopulationElement>().Name.text = PopulationObject.AllSpecialization[i].GetStringName();
            children[i].GetComponent<PanelPopulationElement>().Percents.text = (listCategory[i].PercentSize*100)+"%";
            children[i].GetComponent<PanelPopulationElement>().ColorIcon.color = listCategory[i].CategoryColor;
        }

    }

    private bool CheckCount()
    {
        List<PopulationCategory> listCategory = 
            PopulationObject.GetCategoryList(RaceFlag);
        int count = 0;
        foreach (var category in listCategory)
        {
            if (!category.CheckCondition())
                continue;
            count++;
        }

        if (count == Content.transform.childCount) 
            return true;
        return false;
    }

    private void GetAllChildren(GameObject source, ref List<GameObject> finalList)
    {
        finalList.Clear();
        int children = source.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            finalList.Add(source.transform.GetChild(i).gameObject);
        }
    }

    private void DestroyAllChild(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
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
