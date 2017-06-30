using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysUserInfoMapper : EntityTypeConfiguration<SysUserInfo>
    {
        public SysUserInfoMapper()
        {
            this.ToTable("SysUserInfo");
            this.Property(t => t.Email).HasMaxLength(50);
            this.Property(t => t.HeaderImg).HasMaxLength(100);
            this.Property(t => t.MobilePhone).HasMaxLength(50);
            this.Property(t => t.RealName).HasMaxLength(50);
        }
    }
}
