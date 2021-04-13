using Assets.Scripts.ENUMs;
using UnityEngine;

namespace Assets.Scripts.AllResources
{
    [System.Serializable]
    public class CityResource
    {
        public VisitResources Resource;
        public double Value;

        #region Конструкторы
        public CityResource(VisitResources resource, double value)
        {
            Resource = resource;
            Value = value;
        }
        #endregion

        #region Перегрузки операторов
        public static CityResource operator +(CityResource r1, CityResource r2)
        {
            r1.Value += r2.Value;
            return r1;
        }
        public static CityResource operator *(CityResource r1, double n2)
        {
            r1.Value *= n2;
            return r1;
        }
        #endregion
    }
}