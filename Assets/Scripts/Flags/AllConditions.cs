using System.Collections.Generic;
using Assets.Scripts.ENUMs;
using UnityEngine;

namespace Assets.Scripts.Flags
{
    public class AllConditions
    {
        private Dictionary<Condition, bool> Conditions = new Dictionary<Condition, bool>()
        {
            {Condition.SecondLevel, false },
            {Condition.ThirdLevel, false },
            {Condition.FourLevel, false },
            {Condition.FiveLevel, false },
            {Condition.Guardian, false },
            {Condition.Hunters, false },
            {Condition.Merchants, false },
        };

        #region Индексатор
        public bool this[Condition conVar]
        {
            get { return Conditions[conVar]; }
            set { Conditions[conVar] = value; }
        }

        //public Flag this[Condition conVar]
        //{
        //    get { return new Flag(conVar, Conditions[conVar]);  }
        //    set { Conditions[conVar] = value.ConditionFlag; }
        //}
        #endregion

        #region Конструкторы

        public AllConditions() { }

        //public AllConditions(List<Flag> unitConditions)
        //{
        //    for (int i = 0; i < unitConditions.Count; i++)
        //    {
                
        //    }
        //}

        #endregion

        #region Методы

        public bool CheckConditions(Flag flag)
        {
            if (Conditions[flag.NameCondition] == flag.ConditionFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckListConditions(List<Flag> unitConditions)
        {
            for (int i = 0; i < unitConditions.Count; i++)
            {
                if (!CheckConditions(unitConditions[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public void ChangeConditions(Flag flag)
        {
            Conditions[flag.NameCondition] = flag.ConditionFlag;
        }


        #endregion
    }
}