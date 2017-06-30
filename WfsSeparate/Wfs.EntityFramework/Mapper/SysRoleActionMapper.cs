using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysRoleActionMapper:EntityTypeConfiguration<SysRoleAction>
    {
        public SysRoleActionMapper()
        {
            this.ToTable("SysRoleAction");
        }
    }
}
