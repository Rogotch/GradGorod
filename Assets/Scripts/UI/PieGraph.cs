using Assets.Scripts.PopulationFolder;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PieGraph : MonoBehaviour
    {
        public Image    PiePrefab;
        public Population PopulationScript;
        public double[] Percents;
        public Color[]  Colors;
        public bool Race;

        void Start()
        {
            int countVar;
            if (Race)
            {
                countVar = PopulationScript.AllRaces.Count;
            }
            else
            {
                countVar = PopulationScript.AllSpecialization.Count;
            }
            for (int i = 0; i < countVar; i++)
            {
                Image newWedge = Instantiate(PiePrefab) as Image;
                newWedge.transform.SetParent(transform, false);
            }
        }

        public void UpdatePie()
        {
            float offset = 0;
            for (int i = 0; i < transform.childCount; i++)
            {
                Image wedge = transform.GetChild(i).GetComponent<Image>();
                wedge.fillAmount = (float)Percents[i];
                wedge.color = Colors[i];
                offset += (float)(360 * Percents[i]);
                wedge.transform.rotation = Quaternion.Euler(new Vector3(0, 0, offset));
            }
        }
    }
}