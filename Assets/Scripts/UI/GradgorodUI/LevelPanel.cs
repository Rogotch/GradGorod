using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.GradgorodUI
{
    public class LevelPanel : MonoBehaviour
    {
        public GradgorodLevel LevelParameters;

        public Image LevelImage;
        public Text LevelName;
        public Text LevelDescription;

        public int Level;

        void Start()
        {
        }

        public void UpdatePanelParameters()
        {
            LevelImage.sprite = LevelParameters.LevelImage;
            LevelName.text = LevelParameters.Name;
            LevelDescription.text = LevelParameters.Description;
        }

        public void SetLevelParameters(GradgorodLevel levelParams)
        {
            LevelParameters = levelParams;
            UpdatePanelParameters();
        }
    }
}