using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysUserMapper : EntityTypeConfiguration<SysUser>
    {
        public SysUserMapper()
        {
            this.ToTable("SysUser");
            this.Property(t => t.SysUserName).HasMaxLength(50).IsRequired();
            this.Property(t => t.SysUserPwd).HasMaxLength(50).IsRequired();
            this.Property(t => t.SysUserRandomCode).HasMaxLength(50).IsRequired();
        }
    }
}
