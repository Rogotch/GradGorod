using UnityEngine;

namespace Assets.Scripts.UI.GradgorodUI
{
    public class AllGradgorodLevels : MonoBehaviour
    {
        public GradgorodLevel[] GradgorodLevels = new GradgorodLevel[4];
        public LevelPanel[] LevelObjects = new LevelPanel[4];

        public void SetGradgorodLevel(GradgorodLevel levelObject)
        {
            int lvl = levelObject.Lvl - 2;

            GradgorodLevels[lvl] = levelObject;
            LevelObjects[lvl].SetLevelParameters(levelObject);
        }

        private void UpdateLevels()
        {
            for (int i = 0; i < 4; i++)
            {
                LevelObjects[i].SetLevelParameters(GradgorodLevels[i]);
            }
        }

        void Start()
        {
            UpdateLevels();
        }
    }
}