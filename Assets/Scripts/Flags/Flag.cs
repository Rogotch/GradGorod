using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ENUMs;
using UnityEngine;

[System.Serializable]
public class Flag 
{
    public Condition NameCondition;
    public bool ConditionFlag;

    #region Конструкторы
    public Flag(Condition condition, bool varFlag)
    {
        NameCondition = condition;
        ConditionFlag = varFlag;
    }
    #endregion

}
