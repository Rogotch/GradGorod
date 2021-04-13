using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.AllResources;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int ID;
    public int RequirementId;
    public int Level;
    public string Name;
    public Sprite Icon;
    public int Priority;
    public bool Unique;
    public bool Extension;
    public bool IsBuilt;
    public int ExtensionLimit = 2;

    [TextArea(4, 5)]
    public string Description;

    /// <summary>
    /// Модификаторы прибыли ресурсов
    /// </summary>
    [Tooltip("Модификаторы ресурсов, как здание сказывается на добычу ресурсов")]
    [SerializeField]
    public List<CityResource> ResourceModifiers = new List<CityResource>();

    /// <summary>
    /// Какие флаги нужны для открытия здания
    /// </summary>
    [Tooltip("Какие флаги требуются для постойки этого здания")]
    [SerializeField]
    public List<Flag> Conditions = new List<Flag>();

    /// <summary>
    /// Какие флаги открывает здание
    /// </summary>
    [Tooltip("Какие флаги разблокирует это здание")]
    [SerializeField]
    public List<Flag> UnlockingConditions = new List<Flag>();

    /// <summary>
    /// Какие пристройки есть у здания
    /// </summary>
    [Tooltip("Список пристроек здания")]
    [SerializeField]
    public List<Building> Extensions = new List<Building>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
