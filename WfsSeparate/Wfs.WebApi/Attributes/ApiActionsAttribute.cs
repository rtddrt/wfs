using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wfs.WebApi.Attributes
{
    /// <summary>
    /// 表示为Api的Actions,为反射使用
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiActionsAttribute:Attribute
    {
        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        public ApiActionsAttribute(string description="")
        {
            Description=description;
        }
    }
}