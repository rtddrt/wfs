using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wfs.WebApi.Base
{
    /// <summary>
    /// 忽略权限验证
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple = false)]
    public class IgnoreAttribute : Attribute
    {
    }
}