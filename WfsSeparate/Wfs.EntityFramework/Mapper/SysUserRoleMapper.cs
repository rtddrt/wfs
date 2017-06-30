using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysUserRoleMapper:EntityTypeConfiguration<SysUserRole>
    {
        public SysUserRoleMapper()
        {
            this.ToTable("SysUserRole");
        }
    }
}
