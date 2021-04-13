using System.Collections.Generic;
using Assets.Scripts.Flags;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class BuildingsStack
    {

        private Building[] _buildings;
        public Building ResultConstruction;

        public BuildingsStack(GameObject sourceTemplate, AllConditions conditions)
        {
            GetAllBuildings(sourceTemplate);
            ResultConstruction = ChoiceConstruction(CheckCondition(conditions));
        }

        private void GetAllBuildings(GameObject sourceTemplate)
        {
            int child = sourceTemplate.transform.childCount;
            _buildings = new Building[child];
            for (int i = 0; i < child; i++)
            {
                _buildings[i] = sourceTemplate.transform.GetChild(i).gameObject.GetComponent<Building>();
            }
        }

        private List<Building> CheckCondition(AllConditions conditions)
        {
            List<Building> unlockedBuildings = new List<Building>();
            foreach (var building in _buildings)
            {
                if (conditions.CheckListConditions(building.Conditions))
                    unlockedBuildings.Add(building);
            }

            return unlockedBuildings;
        }

        private Building ChoiceConstruction(List<Building> unlockedBuildings)
        {
            List<Building> _finalBuildings = new List<Building>();
            foreach (var building in unlockedBuildings)
            {
                for (int i = 0; i < building.Priority; i++)
                {
                    _finalBuildings.Add(building);
                }
            }

            return _finalBuildings[UnityEngine.Random.Range(0, _finalBuildings.Count)];
        }
    }
}