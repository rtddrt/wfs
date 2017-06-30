using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysRole : Entity
    {
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public int IsActive { get; set; }
    }
}
