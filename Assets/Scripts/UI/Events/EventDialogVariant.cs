using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.Events
{
    [System.Serializable]
    public class EventDialogVariant
    {
        public string VariantText;

        public EventData NextEvent;

        public bool EndEvent;
        
        [Tooltip("Какие флаги даёт вариант ответа")]
        [SerializeField]
        public List<Flag> AllUnitConditions = new List<Flag>();
    }
}