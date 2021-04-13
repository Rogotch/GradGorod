using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ScrollView : MonoBehaviour
{
    public GameObject sourceTemplate;
    
    public GameObject itemTemplate;

    private List<GameObject> allChildren = new List<GameObject>();

    public GameObject content;


    void Start()
    {
        AddAllItems();
    }
    
    public void AddAllItems()
    {
        GetAllChildren(sourceTemplate, ref allChildren);
        DestroyAllChild();
        for (int i = 0; i < allChildren.Count; i++)
        {
            if (!CheckCondition(allChildren[i]))
                continue;
            var copy = Instantiate(itemTemplate);
            copy.GetComponent<ISVItem>().SetSelectedObject(allChildren[i]);
            copy.GetComponent<ISVItem>().UpdateParameters();
            copy.transform.SetParent(content.transform);
            copy.transform.localScale = Vector3.one;
        }
    }

    private bool CheckCondition(GameObject item)
    {
        itemTemplate.GetComponent<ISVItem>().SetSelectedObject(item);
        itemTemplate.GetComponent<ISVItem>().UpdateParameters();
        return itemTemplate.GetComponent<ISVItem>().CheckingTheCondition();
    }
    public void SetSource(GameObject obj)
    {
        sourceTemplate = obj;
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

    private void DestroyAllChild()
    {
        foreach (Transform child in content.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
