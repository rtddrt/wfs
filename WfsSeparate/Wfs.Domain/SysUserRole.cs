using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain.Base;

namespace Wfs.Domain
{
    public class SysUserRole : Entity
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }
    }
}
