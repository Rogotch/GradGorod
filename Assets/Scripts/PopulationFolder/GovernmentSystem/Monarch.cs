using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PopulationFolder.GovernmentSystem
{
    public class Monarch : MonoBehaviour
    { 
        public Population CityPopulation;
        public Person monarch;
        public Race MonarchRace;
        public Specialization MonarchSpec;

        public void GenerateGov()
        {
            monarch = new Person();
            monarch.Name = "Krol";
            double num = 0.0;
            double randPercentNum = UnityEngine.Random.value;

            foreach (var race in CityPopulation.AllRaces)
            {
                if (num <= randPercentNum && randPercentNum <= (num + race.PercentSize))
                {
                    MonarchRace = race;
                    monarch.PersonRace = race.Type;
                }

                num += race.PercentSize;
            }

            num = 0.0;
            randPercentNum = UnityEngine.Random.value;

            foreach (var specialization in CityPopulation.AllSpecialization)
            {
                if (num <= randPercentNum && randPercentNum <= (num + specialization.PercentSize))
                {
                    MonarchSpec = specialization;
                    monarch.PersonSpecialization = specialization.Type;
                }

                num += specialization.PercentSize;
            }
        }
    }
}