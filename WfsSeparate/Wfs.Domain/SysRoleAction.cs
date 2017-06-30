using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysRoleAction:Entity
    {
        public Guid RoleId { get; set; }

        public Guid ActionId { get; set; }
    }
}
