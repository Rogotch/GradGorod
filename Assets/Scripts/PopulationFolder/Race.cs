using System.Drawing;
using Assets.Scripts.ENUMs;
using UnityEngine;
using Color = UnityEngine.Color;

namespace Assets.Scripts.PopulationFolder
{
    [System.Serializable]
    public class Race : PopulationCategory
    {
        public RaceType Type;

        public static Race operator +(Race r1, Race r2)
        {
            r1.PopulationCount += r2.PopulationCount;
            return r1;
        }

        public static Population operator +(Population p1, Race r2)
        {
            p1[r2.Type].PopulationCount += r2.PopulationCount;
            return p1;
        }

        public new string GetStringName()
        {
            string raceName;
            switch (Type)
            {
                case RaceType.Dragonborn:
                {
                    raceName = "Драконорождённый";
                    break;
                }
                case RaceType.Dwarf:
                {
                    raceName = "Дварф";
                    break;
                }
                case RaceType.Elf:
                {
                    raceName = "Эльф";
                    break;
                }
                case RaceType.Gnome:
                {
                    raceName = "Гном";
                    break;
                }
                case RaceType.Human:
                {
                    raceName = "Человек";
                    break;
                }
                case RaceType.Skeleton:
                {
                    raceName = "Скелет";
                    break;
                }
                case RaceType.Orc:
                {
                    raceName = "Орк";
                    break;
                }
                case RaceType.Sneak:
                {
                    raceName = "Змея";
                    break;
                }
                default:
                {
                    raceName = "None";
                    break;
                }
            }

            return raceName;
        }
    }
}