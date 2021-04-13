using Assets.Scripts.PopulationFolder;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PanelPopulationElement : MonoBehaviour
    {
        public PopulationCategory Category;
        public Text Percents;
        public Text Name;
        public Image ColorIcon;

        public bool CheckingTheCondition()
        {
            if (Category.PercentSize > 0)
                return true;
            return false;
        }

        public void UpdatePanel(Color objColor, double percent, string name)
        {
            ColorIcon.color = objColor;
            Name.text = name;
            Percents.text = percent*100 + "%";
        }

    }
}