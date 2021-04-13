using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Events
{
    [System.Serializable]
    public class EventData : MonoBehaviour
    {
        public Sprite ImageEvent;
        public string NameEvent;

        [TextArea(4, 5)]
        public string DescriptionText;

        [SerializeField]
        public List<EventDialogVariant> DialogVariants;
    }
}