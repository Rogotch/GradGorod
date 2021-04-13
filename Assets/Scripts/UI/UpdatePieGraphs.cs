using System.Collections;
using UnityEngine;
using Assets.Scripts.PopulationFolder;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UpdatePieGraphs : MonoBehaviour
    {
        public PieGraph RacePie;
        public PieGraph SpecializationPie;
        public Text RaceCount;
        public Text SpecializationCount;
        public Population PopulationScript;

        void Start()
        {
            StartCoroutine(updatePie());
        }

        protected void PieUpdate(PieGraph pie, double[] percents, Color[] colors)
        {
            pie.Percents = percents;
            pie.Colors = colors;
            pie.UpdatePie();
        }

        public void UpdateCount(Text textObject, int sourceCount)
        {
            textObject.text = ""+sourceCount;
        }

        IEnumerator updatePie()
        {
            while (true)
            {
                if (PopulationScript.PopulationSize == 0)
                {
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    PopulationScript.SortLists();
                    double[] percents;
                    Color[] colors;
                    PopulationScript.GetPercentAndColorArr(out percents, out colors, true);
                    PieUpdate(RacePie, percents, colors);
                    PopulationScript.GetPercentAndColorArr(out percents, out colors, false);
                    PieUpdate(SpecializationPie, percents, colors);
                    UpdateCount(RaceCount, PopulationScript.PopulationSize);
                    UpdateCount(SpecializationCount, PopulationScript.ProfessionalsSize);
                    yield return new WaitForSeconds(1);
                }
            }
        }
    }
}