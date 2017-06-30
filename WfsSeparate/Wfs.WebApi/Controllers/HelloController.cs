using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using Wfs.Core;
using Wfs.WebApi.Attributes;
using Wfs.WebApi.Base;

namespace Wfs.WebApi.Controllers
{
    public class HelloController : BaseApiController
    {
        [ApiActions("示例-hello")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var list= SystemActionsHelper.GetActions();
            return Json(list);
        }

        [ApiActions("示例-获取无限层级树")]
        [HttpGet]
        public IHttpActionResult GetDemoTree(string id)
        {
            var tree=new Tree(){Id="0",PId = "",Name=id};
            TreeHelper.GenerateTree(ListTree(),tree);
            return Json(tree.Children);
        }

        public void Delete()
        {
            
        }

        public List<Tree> ListTree()
        {
            var list = new List<Tree>()
            {
                new Tree(){Id="1",PId = "0",Name = "1"},
                new Tree(){Id="10",PId = "1",Name = "10"},
                    new Tree(){Id="100",PId = "10",Name = "100"},
                        new Tree(){Id="1000",PId = "100",Name = "1000"},
                    new Tree(){Id="101",PId = "10",Name = "101"},
                new Tree(){Id="2",PId = "0",Name = "2"},
                new Tree(){Id="20",PId = "2",Name = "20"},
                new Tree(){Id="3",PId = "0",Name = "3"},
                new Tree(){Id="30",PId = "3",Name = "30"},
            };
            return list;
        }
    }
}
