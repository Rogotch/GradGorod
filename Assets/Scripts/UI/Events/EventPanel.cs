using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Events
{
    public class EventPanel : MonoBehaviour
    {
        public EventData Event;

        public Text EventName;
        public Image EventImage;
        public Text EventDescription;

        public GameObject ItemVariantDialog;
        public GameObject Content;

        public GameObject Out;
        public GameObject In;

        [SerializeField]
        public List<EventDialogVariant> DialogVariants;

        void Start()
        {
            UpdateEventPanel();
        }

        public void UpdateEventPanel()
        {
            DestroyAllChild();
            EventUpdateInfo();
            foreach (var variant in DialogVariants)
            {
                var eventVariant = Instantiate(ItemVariantDialog);
                eventVariant.GetComponent<DialogButton>().EventVariant = variant;
                eventVariant.GetComponent<DialogButton>().UpdateText();
                eventVariant.GetComponent<DialogButton>().EventPanel = gameObject;
                eventVariant.transform.SetParent(Content.transform);
                eventVariant.transform.localScale = Vector3.one;
            }
        }

        private void EventUpdateInfo()
        {
            EventName.text = Event.NameEvent;
            EventDescription.text = Event.DescriptionText;
            EventImage.sprite = Event.ImageEvent;
            DialogVariants = Event.DialogVariants;
        }
        
        private void DestroyAllChild()
        {
            foreach (Transform child in Content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public void GoIn(EventData newEvent)
        {
            Event = newEvent;
            UpdateEventPanel();
            transform.position = In.transform.position;
        }
        public void GoOut()
        {
            transform.position = Out.transform.position;
        }


    }
}