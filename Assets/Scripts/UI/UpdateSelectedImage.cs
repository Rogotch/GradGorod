using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSelectedImage : MonoBehaviour
{
    public GameObject[] SelectedItems = new GameObject[5];
    public Sprite Stub;

    // Start is called before the first frame update

    public void UpdateImages(Visitor[] visitors)
    {
        for (int i = 0; i < visitors.Length; i++)
        {
            if (visitors[i] != null && visitors[i].Level != 0)
            {
                SelectedItems[i].GetComponent<Image>().sprite = visitors[i].Icon;
            }
            else
            {
                SelectedItems[i].GetComponent<Image>().sprite = Stub;
            }
        }
    }
    public void UpdateImages(Building[] buildings)
    {
        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i] != null && buildings[i].Level != 0)
            {
                SelectedItems[i].GetComponent<Image>().sprite = buildings[i].Icon;
            }
            else
            {
                SelectedItems[i].GetComponent<Image>().sprite = Stub;
            }
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
