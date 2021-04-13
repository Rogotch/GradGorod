using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public GameObject ScrollViewObject;
    public GameObject Source;
    public GameObject Image;
    public GameObject Latch;

    // Start is called before the first frame update

    public void MouseClack()
    {
        ScrollViewObject.GetComponent<ScrollView>().sourceTemplate = Source;
        ScrollViewObject.GetComponent<ScrollView>().AddAllItems();
        Latch.transform.position = new Vector3(Image.transform.position.x, Latch.transform.position.y, Latch.transform.position.z);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
