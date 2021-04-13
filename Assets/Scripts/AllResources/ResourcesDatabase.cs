using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

namespace Assets.Scripts.AllResources
{
    [System.Serializable]
    public class ResourcesDatabase : ScriptableObject
    {
        public List<CityResource> AllResources = new List<CityResource>();
    }
}