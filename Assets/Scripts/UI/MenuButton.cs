using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public ScrollRect ScrollRectObj;

    public RectTransform ContentPanel;

    public RectTransform Target;

    public void SnapTo()
    {
        Canvas.ForceUpdateCanvases();

        ContentPanel.anchoredPosition =
            (Vector2) ScrollRectObj.transform.InverseTransformPoint(ContentPanel.position)
            - (Vector2) ScrollRectObj.transform.InverseTransformPoint(Target.position);
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
