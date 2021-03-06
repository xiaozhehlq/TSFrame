﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TSFrame.ECS
{
    public class Collision2DComponent : IComponent, IReactiveComponent
    {
        public Int64 OperatorId
        {
            get
            {
                return OperatorIds.COLLISION2D;
            }
        }
        [DataDriven]
        private bool isPhysical;

        private List<Collision2DModel> collisionList;

        private Collision2DCallBack enterCallBack;

        private Collision2DCallBack stayCallBack;

        private Collision2DCallBack exitCallBack;

    }
}

