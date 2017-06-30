using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Wfs.Application;
using Wfs.Application.SystemDto;
using Wfs.Core;
using Wfs.WebApi.Attributes;

namespace Wfs.WebApi
{
    /// <summary>
    /// 获取系统内所有的controller 和Action
    /// </summary>
    public class SystemActionsHelper
    {
        /// <summary>
        /// 获取所有Actions
        /// </summary>
        public static List<SysActionDto> GetActions()
        {
            var assemblies = Assembly.GetExecutingAssembly().DefinedTypes.ToList();
            var controllerList = assemblies.Where(x => x.FullName.Contains("Wfs.WebApi.Controllers")).ToList();

            var list = new List<SysActionDto>();
            foreach (var controller in controllerList)
            {
                    foreach (var action in controller.DeclaredMethods)
                    {
                        var attr = action.GetCustomAttribute(typeof(ApiActionsAttribute));
                        if (attr != null)
                        {
                            var apiAttr = attr as ApiActionsAttribute;
                            string lastpre = "Controller";
                            var controllerName = controller.Name.Substring(0,controller.Name.Length-lastpre.Length);
                            var model = new SysActionDto()
                            {
                                Id = new Guid((controllerName+action.Name).ToMd5()),
                                ControllerName = controllerName,
                                ActionName = action.Name,
                                Description = apiAttr.Description,
                                CreateOne = new Guid("169C5F63-4FA8-4E36-A5A2-878B8BA2893D"),
                                CreationTime = DateTime.Now,
                                IsActive = 1
                            };
                            list.Add(model);
                        }
                    }
            }
            return list;
        }

        public static void InitSystemAction()
        {
            var application = IocRegister.GetType<SystemApplication>();
            var list = GetActions();
            application.InitSysAction(list);
        }
    }

}