using System.Collections.Generic;
using Assets.Scripts.Flags;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ExtensionPanel : MonoBehaviour
    {
        public Building BuildingExtension;
        public Text Name;
        public Image Icon;
        public Text Description;

        // Start is called before the first frame update
        void Start()
        {
            UpdateParameters();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UpdateParameters()
        {
            Name.text = BuildingExtension.Name;
            Description.text = BuildingExtension.Description;
            Icon.sprite = BuildingExtension.Icon;
        }

        public void SetSelectedObject(Building obj)
        {
            BuildingExtension = obj;
            UpdateParameters();
        }

        public bool CheckingTheCondition()
        {

            return true;
        }
    }
}