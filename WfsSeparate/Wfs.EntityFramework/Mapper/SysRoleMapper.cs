using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
   public class SysRoleMapper:EntityTypeConfiguration<SysRole>
    {
        public SysRoleMapper()
        {
            this.ToTable("SysRole");
            this.HasKey(t => t.Id);
            this.Property(t => t.RoleName).HasMaxLength(50).IsRequired();
            this.Property(t => t.RoleDescription).HasMaxLength(100);
        }
    }
}
