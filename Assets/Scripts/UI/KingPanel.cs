using Assets.Scripts.PopulationFolder.GovernmentSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class KingPanel : MonoBehaviour
    {
        public Text KingName;
        public Monarch MonarchPerson;

        public void UpdateKingName()
        {
            KingName.text = MonarchPerson.monarch.Name + ", "
                                               + MonarchPerson.MonarchRace.GetStringName() + "-" 
                                               + MonarchPerson.MonarchSpec.GetStringName();
        }
    }
}