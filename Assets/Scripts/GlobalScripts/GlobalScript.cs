using System.Collections;
using Assets.Scripts.Flags;
using Assets.Scripts.PopulationFolder;
using UnityEngine;

namespace Assets.Scripts.GlobalScripts
{
    public class GlobalScript : MonoBehaviour
    {
        public global::Visitor[] AllVisitors = new global::Visitor[5];
        public Building[] AllBuildings = new Building[5];
        public bool[] LockRemove = new[] {false, false, false, false, false};

        public Building BuildingStub;
    
        public AllResources.AllResources PlayerResources = new AllResources.AllResources();

        public Population CityPopulation;

        public AllConditions Conditions = new AllConditions();

        public GameObject SelectedVisitorsObjects;
        public GameObject SelectedBuildingsObjects;
        public BuildingPanel BuildingPanelObj;
        // Start is called before the first frame update
        void Start()
        {
            UpdateImg();
            StartCoroutine(resources());
            StartCoroutine(population());
        }

        // Update is called once per frame
        void FixedUpdate()
        {

        }

        public void UpdateImg()
        {
            SelectedVisitorsObjects.GetComponent<UpdateSelectedImage>().UpdateImages(AllVisitors);
            SelectedBuildingsObjects.GetComponent<UpdateSelectedImage>().UpdateImages(AllBuildings);
            BuildingPanelObj.UpdateParameters();

        }
        public void ChangeVisitor(global::Visitor visitorObject, int level)
        {
            AllVisitors[level - 1] = visitorObject;
            SelectedVisitorsObjects.GetComponent<UpdateSelectedImage>().UpdateImages(AllVisitors);
        }

        public void ChangeBuilding(Building buildingObject, int level)
        {
            AllBuildings[level - 1] = buildingObject;
            SelectedBuildingsObjects.GetComponent<UpdateSelectedImage>().UpdateImages(AllBuildings);
        }
        IEnumerator resources()
        {
            while (true)
            {
                AllResources.AllResources visitorsRes = new AllResources.AllResources(AllVisitors[0].AllUnitResources) +
                                                        new AllResources.AllResources(AllVisitors[1].AllUnitResources) +
                                                        new AllResources.AllResources(AllVisitors[2].AllUnitResources) +
                                                        new AllResources.AllResources(AllVisitors[3].AllUnitResources) +
                                                        new AllResources.AllResources(AllVisitors[4].AllUnitResources);

                PlayerResources += visitorsRes * 0.25f;
                yield return new WaitForSeconds(.25f);
            }
        }

        IEnumerator population()
        {
            while(true)
            {
                CityPopulation.PopulationIncrease(AllVisitors[0].RaceType, AllVisitors[0].SpecializationType);
                CityPopulation.PopulationIncrease(AllVisitors[1].RaceType, AllVisitors[1].SpecializationType);
                CityPopulation.PopulationIncrease(AllVisitors[2].RaceType, AllVisitors[2].SpecializationType);
                CityPopulation.PopulationIncrease(AllVisitors[3].RaceType, AllVisitors[3].SpecializationType);
                CityPopulation.PopulationIncrease(AllVisitors[4].RaceType, AllVisitors[4].SpecializationType);
                CityPopulation.SCRaces.CheckCategories();
                CityPopulation.SCSpecializations.CheckCategories();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
