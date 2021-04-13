using System.Drawing;
using Assets.Scripts.ENUMs;
using UnityEngine;
using Color = UnityEngine.Color;

namespace Assets.Scripts.PopulationFolder
{
    [System.Serializable]
    public class Specialization : PopulationCategory
    {
        public SpecializationType Type;

        #region Перегрузки операторов

        public static Specialization operator +(Specialization s1, Specialization s2)
        {
            s1.PopulationCount += s2.PopulationCount;
            return s1;
        }

        public static Population operator +(Population p1, Specialization s2)
        {
            p1[s2.Type].PopulationCount += s2.PopulationCount;
            return p1;
        }

        #endregion

        public new string GetStringName()
        {
            string specializationName;
            switch (Type)
            {
                case SpecializationType.Engineer:
                {
                    specializationName = "Инженер";
                    break;
                }
                case SpecializationType.Farmer:
                {
                    specializationName = "Фермер";
                    break;
                }
                case SpecializationType.Hunter:
                {
                    specializationName = "Охотник";
                    break;
                }
                case SpecializationType.Wizard:
                {
                    specializationName = "Волшебник";
                    break;
                }
                case SpecializationType.Warrior:
                {
                    specializationName = "Воин";
                    break;
                }
                case SpecializationType.Scientist:
                {
                    specializationName = "Учёный";
                    break;
                }
                case SpecializationType.Revolutionary:
                {
                    specializationName = "Революционер";
                    break;
                }
                case SpecializationType.Priest:
                {
                    specializationName = "Священник";
                    break;
                }
                case SpecializationType.Jester:
                {
                    specializationName = "Шут";
                    break;
                }
                case SpecializationType.Inventor:
                {
                    specializationName = "Изобретатель";
                    break;
                }
                default:
                {
                    specializationName = "None";
                    break;
                }
            }
            return specializationName;
        }
    }
}