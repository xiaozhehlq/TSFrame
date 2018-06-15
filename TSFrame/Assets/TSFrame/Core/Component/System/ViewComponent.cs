﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ViewComponent : IComponent, IReactiveComponent
{
    public Int64 CurrentId
    {
        get
        {
            return ComponentIds.VIEW;
        }
    }
    [DataDriven]
    private string prefabName;
    private Transform parent;
    private Vector3 pos;
    private Quaternion rot;
    private HideFlags hideFlags;
}
