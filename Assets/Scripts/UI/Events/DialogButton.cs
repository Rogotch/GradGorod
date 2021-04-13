using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Events
{
    public class DialogButton : MonoBehaviour
    {
        public Text ButtonText;
        public EventDialogVariant EventVariant;

        public GameObject EventPanel;

        public void UpdateText()
        {
            ButtonText.text = EventVariant.VariantText;
        }

        public void ButtonClick()
        {
            if (!EventVariant.EndEvent)
            {
                EventPanel.GetComponent<EventPanel>().Event = EventVariant.NextEvent;
                EventPanel.GetComponent<EventPanel>().UpdateEventPanel();
                UpdateText();
            }
            else
            {
                EventPanel.GetComponent<EventPanel>().GoOut();
            }
        }
    }
}