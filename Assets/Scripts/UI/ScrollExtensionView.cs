using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ScrollExtensionView : MonoBehaviour
    {
        public Building BuildingSource;
        public GameObject itemTemplate;
        public GameObject content;


        void Start()
        {
            AddAllItems();
        }

        public void AddAllItems()
        {
            DestroyAllChild();
            for (int i = 0; i < BuildingSource.Extensions.Count; i++)
            {
                var copy = Instantiate(itemTemplate);
                copy.GetComponent<ExtensionPanel>().SetSelectedObject(BuildingSource.Extensions[i]);
                copy.transform.SetParent(content.transform);
                copy.transform.localScale = Vector3.one;
            }
        }

        private bool CheckCondition(GameObject item)
        {
            itemTemplate.GetComponent<ISVItem>().SetSelectedObject(item);
            itemTemplate.GetComponent<ISVItem>().UpdateParameters();
            return itemTemplate.GetComponent<ISVItem>().CheckingTheCondition();
        }
        public void SetSource(GameObject obj)
        {
            //sourceTemplate = obj;
        }

        private void GetAllChildren(GameObject source, ref List<GameObject> finalList)
        {
            finalList.Clear();
            int children = source.transform.childCount;
            for (int i = 0; i < children; i++)
            {
                finalList.Add(source.transform.GetChild(i).gameObject);
            }
        }

        private void DestroyAllChild()
        {
            foreach (Transform child in content.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}