using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI.GradgorodUI
{
    [System.Serializable]
    public class GradgorodLevel : MonoBehaviour
    {
        public int Lvl;
        public Sprite LevelImage;
        public string Name;
        
        [TextArea(3,5)]
        public string Description;
        public List<Flag> Conditions;

    }
}