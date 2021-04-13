using UnityEngine;

namespace Assets.Scripts.PopulationFolder
{
    public class PopulationCategory
    {
        public int PopulationCount;
        public double PercentSize;
        public Color CategoryColor;

        public bool CheckCondition()
        {
            if (PercentSize > 0)
                return true;
            return false;
        }
        public string GetStringName()
        {
            return "Empty будь здоров";
        }
    }
}