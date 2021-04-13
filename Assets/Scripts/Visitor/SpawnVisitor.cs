using Assets.Scripts.GlobalScripts;
using UnityEngine;

namespace Assets.Scripts.Visitor
{
    public class SpawnVisitor : MonoBehaviour, ISpawn
    {
        public int Lvl;

        public GameObject SelectedVis;

        void Start()
        {
            ChangeSprite();
        }

        private void ChangeSprite()
        {
            Lvl = UnityEngine.Random.Range(1, 6);
            if (SelectedVis.GetComponent<GlobalScript>().AllVisitors[Lvl - 1] != null)
            {
                global::Visitor unit = SelectedVis.GetComponent<GlobalScript>().AllVisitors[Lvl - 1];
                Sprite Icon = unit.Icon;
                if (Icon != null)
                    GetComponent<SpriteRenderer>().sprite = Icon;

            }

        }

        public void ReloadParams(GameObject _object = null)
        {
            ChangeSprite();
        }
    }
}