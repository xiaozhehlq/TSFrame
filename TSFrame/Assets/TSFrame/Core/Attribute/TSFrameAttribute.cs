﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSFrame.ECS
{
    /// <summary>
    /// 数据驱动特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DataDrivenAttribute : Attribute
    {

    }
    /// <summary>
    /// 不要拷贝特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DontCopyAttribute : Attribute
    {

    }

    /// <summary>
    /// 不要拷贝特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class DefaultValueAttribute : Attribute
    {
        private object _value;
        public object Value { get { return _value; } }
        public DefaultValueAttribute(object value)
        {
            _value = value;
        }
    }
}