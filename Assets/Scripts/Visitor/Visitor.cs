using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.AllResources;
using Assets.Scripts.ENUMs;
using Assets.Scripts.PopulationFolder;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Visitor : MonoBehaviour
{
    public int ID { get; private set; }

    public string Name;

    public int Level;

    public Sprite Icon;

    [Tooltip("Краткое описание Юнита")]
    [TextArea(4,5)]
    public string Description;

    [Tooltip("Какие ресурсы производит юнит")]
    [SerializeField]
    public List<CityResource> AllUnitResources = new List<CityResource>();

    [Tooltip("Какие флаги требуются для разблокировки Юнита")]
    [SerializeField] 
    public List<Flag> AllUnitConditions = new List<Flag>();

    [Tooltip("Какие расы привносит гость")]
    [SerializeField]
    public List<Race> RaceType = new List<Race>();

    [Tooltip("Какие специализации привносит гость")]
    [SerializeField]
    public List<Specialization> SpecializationType = new List<Specialization>();
}
