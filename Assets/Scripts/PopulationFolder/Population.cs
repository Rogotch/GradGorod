using System;
using System.Collections.Generic;
using Assets.Scripts.ENUMs;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

namespace Assets.Scripts.PopulationFolder
{
    public class Population : MonoBehaviour
    {
        public List<Race> AllRaces;
        public List<Specialization> AllSpecialization;
        public ScrollViewPopulation SCRaces;
        public ScrollViewPopulation SCSpecializations;
        public int PopulationSize;
        public int ProfessionalsSize;

        #region Индексаторы
        public Race this[RaceType type]
        {
            get
            {
                int index;
                index = GetIndex(type);
                CalculateRaceSize(index);
                return AllRaces[index];
            }
            set
            {
                int index;
                index = GetIndex(type);
                AllRaces[index] += value;
            }
        }

        public Specialization this[SpecializationType type]
        {
            get
            {
                int index;
                index = GetIndex(type);
                CalculateSpecializationSize(index);
                return AllSpecialization[index];

            }
            set
            {
                int index;
                index = GetIndex(type);
                CalculateSpecializationSize(index);
                AllSpecialization[index] += value;
            }
        }



        #endregion

        #region Перегрузки операторов
        public static Population operator +(Population p1, List<Race> r2)
        {
            int pSize = 0;
            for (int i = 0; i < r2.Count; i++)
            {
                pSize += r2[i].PopulationCount;
                p1[r2[i].Type].PopulationCount += r2[i].PopulationCount;
            }
            
            return p1;
        }

        public static Population operator +(Population p1, List<Specialization> s2)
        {
            int pSize = 0;
            for (int i = 0; i < s2.Count; i++)
            {
                pSize += s2[i].PopulationCount;
                p1[s2[i].Type].PopulationCount += s2[i].PopulationCount;
            }

            return p1;
        }
        #endregion

        public void CalculateRaceSize(int index)
        {
            AllRaces[index].PercentSize =
                (double)AllRaces[index].PopulationCount / 
                (double)PopulationSize;
            AllRaces[index].PercentSize = Math.Round(AllRaces[index].PercentSize, 3, MidpointRounding.AwayFromZero);
        }

        public void CalculateSpecializationSize(int index)
        {
            AllSpecialization[index].PercentSize =
                (double) AllSpecialization[index].PopulationCount /
                (double) ProfessionalsSize;
            AllSpecialization[index].PercentSize =
                Math.Round(AllSpecialization[index].PercentSize, 3, MidpointRounding.AwayFromZero);
        }

        public void CalculateAllRaceSize()
        {
            for (int i = 0; i < AllRaces.Count; i++)
            {
                CalculateRaceSize(i);
            }
        }
        public void CalculateAllSpecializationSize()
        {
            for (int i = 0; i < AllSpecialization.Count; i++)
            {
                CalculateSpecializationSize(i);
            }
        }

        private int GetIndex(RaceType type)
        {
            int index = 0;

            for (int i = 0; i < AllRaces.Count; i++)
            {
                if (AllRaces[i].Type == type)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
        private int GetIndex(SpecializationType type)
        {
            int index = 0;

            for (int i = 0; i < AllRaces.Count; i++)
            {
                if (AllSpecialization[i].Type == type)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Переработать эту хуёвину
        /// </summary>
        /// <param name="raceList"></param>
        /// <param name="specializationList"></param>
        public void PopulationIncrease(List<Race> raceList, List<Specialization> specializationList)
        {
            for (int i = 0; i < raceList.Count; i++)
            {
                for (int j = 0; j < AllRaces.Count; j++)
                {
                    if (AllRaces[j].Type == raceList[i].Type)
                    {
                        PopulationSize += raceList[i].PopulationCount;
                        AllRaces[j] += raceList[i];
                    }

                }
            }
            for (int k = 0; k < specializationList.Count; k++)
            {
                for (int i = 0; i < AllSpecialization.Count; i++)
                {
                    if (AllSpecialization[i].Type == specializationList[k].Type)
                    {
                        ProfessionalsSize += specializationList[k].PopulationCount;
                        AllSpecialization[i] += specializationList[k];
                    }

                }
            }
            CalculateAllSpecializationSize();
            CalculateAllRaceSize();
        }

        public void SortLists()
        {
            AllRaces.Sort(delegate(Race r1, Race r2) { return r2.PercentSize.CompareTo(r1.PercentSize); });
            AllSpecialization.Sort(delegate(Specialization s1, Specialization s2)
            {
                return s2.PercentSize.CompareTo(s1.PercentSize);
            });
        }

        public void GetPercentAndColorArr(out double[] percentArr, out Color[] colorArr, bool race)
        {
            List<PopulationCategory> categoryList = GetCategoryList(race);
            percentArr = new double[categoryList.Count];
            colorArr = new Color[categoryList.Count];

            for (int i = 0; i < categoryList.Count; i++)
            {
                percentArr[i] = categoryList[i].PercentSize;
                colorArr[i] = categoryList[i].CategoryColor;
            }
        }

        public List<PopulationCategory> GetCategoryList(bool raceFlag)
        {
            List<PopulationCategory> categoryList = new List<PopulationCategory>();

            if (raceFlag)
            {
                foreach (var race in AllRaces)
                {
                    categoryList.Add(race);
                }
            }
            else
            {
                foreach (var specialization in AllSpecialization)
                {
                    categoryList.Add(specialization);
                }
            }

            return categoryList;
        }

        public void Start()
        {
            CalculateAllRaceSize();
            CalculateAllSpecializationSize();
        }

    }
}