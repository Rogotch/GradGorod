using System;
using System.Collections.Generic;
using Assets.Scripts.ENUMs;

namespace Assets.Scripts.AllResources
{
    public class AllResources
    {
        private Dictionary<VisitResources, double> AllRes = new Dictionary<VisitResources, double>()
        {
            {VisitResources.Money, 0 },
            {VisitResources.Food, 0 },
            {VisitResources.Army, 0 },
            {VisitResources.Materials, 0 }
        };


        #region Индексаторы
        public CityResource this[VisitResources resource]
        {
            get
            {
                return new CityResource(resource, AllRes[resource]);
            }
            set
            {
                CityResource res = value;
                AllRes[res.Resource] = res.Value;
            }
        }
        public CityResource this[int resourceIndex]
        {
            get
            {
                return new CityResource((VisitResources)resourceIndex, AllRes[(VisitResources)resourceIndex]);
            }
            set
            {
                CityResource res = value;
                AllRes[res.Resource] = res.Value;
            }
        }

        #endregion

        #region Перегрузки операторов
        public static AllResources operator +(AllResources r1, AllResources r2)
        {
            AllResources newR = new AllResources();
            for (int i = 0; i < r1.Length(); i++)
            {
                newR[i] = r1[i] + r2[i];
            }

            return newR;
        }
        public static AllResources operator *(AllResources r1, AllResources r2)
        {
            AllResources newR = new AllResources();
            for (int i = 0; i < r1.Length(); i++)
            {
                newR[i].Value = r1[i].Value * r2[i].Value;
            }

            return newR;
        }

        public static AllResources operator *(AllResources r1, double n2)
        {
            for (int i = 0; i < r1.Length(); i++)
            {
                r1[i] *= n2;
            }

            return r1;
        }

        #endregion

        #region Конструкторы
        public AllResources() { }
        public AllResources(List<CityResource> listRes)
        {
            for (int i = 0; i < listRes.Count; i++)
            {
                AllRes[listRes[i].Resource] = listRes[i].Value;
            }
        }
        #endregion

        public int Length()
        {
            return AllRes.Count;
        }
        public double Value(VisitResources resource)
        {
            return AllRes[resource];
        }
    }
}