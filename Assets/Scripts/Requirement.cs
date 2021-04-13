using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirement
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool Flag { get; private set; }


    /// <param name="id">Уникальный идентификатор требования</param>
    /// <param name="name">Имя требования</param>
    /// <param name="flag">Тумблер требования</param>
    public Requirement(int id, string name, bool flag)
    {
        Id = id;
        Name = name;
        Flag = flag;
    }
}
