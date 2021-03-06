﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TSFrame.ECS
{
    public class LifeCycleSystem : IExecuteSystem, IReactiveSystem
    {
        class DelayEntity
        {
            public Entity CurrentEntity { get; set; }
            public float DelayTime { get; set; }
            public override int GetHashCode()
            {
                return CurrentEntity.GetHashCode();
            }
        }
        private List<DelayEntity> delayList = new List<DelayEntity>();
        private List<DelayEntity> tempList = new List<DelayEntity>();

        private ComponentFlag _condition = null;
        public ComponentFlag ReactiveCondition
        {
            get
            {
                if (_condition == null)
                {
                    _condition = Observer.Instance.GetFlag(OperatorIds.LIFE_CYCLE);
                }
                return _condition;
            }
        }
        public ComponentFlag ExecuteCondition
        {
            get
            {
                if (_condition == null)
                {
                    _condition = Observer.Instance.GetFlag(OperatorIds.LIFE_CYCLE);
                }
                return _condition;
            }
        }

        public ComponentFlag ReactiveIgnoreCondition { get { return ComponentFlag.None; } }

        public void Execute(List<Entity> entitys)
        {
            foreach (Entity item in entitys)
            {
                LifeCycleEnum lifeEnum = item.GetValue<LifeCycleEnum>(LifeCycleComponentVariable.lifeCycle);
                switch (lifeEnum)
                {
                    case LifeCycleEnum.Destory:
                        Observer.Instance.RecoverEntity(item);
                        break;
                    case LifeCycleEnum.DelayDestory:
                        float delayTime = item.GetValue<float>(LifeCycleComponentVariable.dealyTime);
                        delayList.Add(new DelayEntity() { CurrentEntity = item, DelayTime = delayTime });
                        break;
                    case LifeCycleEnum.DontDestory:
                    case LifeCycleEnum.None:
                    default:
                        break;
                }
            }
        }

        public void Execute()
        {
            if (delayList.Count > 0)
            {
                tempList.Clear();
                foreach (DelayEntity item in delayList)
                {
                    item.DelayTime -= Time.deltaTime;
                    if (item.DelayTime <= 0)
                    {
                        tempList.Add(item);
                    }
                }
                if (tempList.Count > 0)
                {
                    foreach (DelayEntity item in tempList)
                    {
                        delayList.Remove(item);
                        item.CurrentEntity.SetValue(LifeCycleComponentVariable.lifeCycle, LifeCycleEnum.Destory);
                    }
                }
                tempList.Clear();
            }

        }
    }
}
