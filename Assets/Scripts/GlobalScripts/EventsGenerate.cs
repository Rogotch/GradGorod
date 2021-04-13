using Assets.Scripts.UI.Events;
using UnityEngine;

namespace Assets.Scripts.GlobalScripts
{
    public class EventsGenerate : MonoBehaviour
    {
        public EventPanel EventPanelObj;
        public EventData Event;

        public void GameEventStart()
        {
            EventPanelObj.GoIn(Event);
            //EventPanelObj.UpdateEventPanel();
        }
    }
}