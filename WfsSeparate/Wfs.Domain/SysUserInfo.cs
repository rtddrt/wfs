using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysUserInfo : Entity,ILogicalRemove
    {
        public Guid UserId { get; set; }

        public string RealName { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public int Sex { get; set; }

        public string HeaderImg { get; set; }

        public int IsDelete { get; set; }
    }
}
