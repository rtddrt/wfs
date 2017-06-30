using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysMenuMapper : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuMapper()
        {
            this.ToTable("SysMenu");
            this.HasKey(t => t.Id);
            this.Property(t => t.Icon).HasMaxLength(50);
            this.Property(t => t.ActionName).HasMaxLength(50).IsRequired();
            this.Property(t => t.ControllerName).HasMaxLength(50).IsRequired();
            this.Property(t => t.Description).HasMaxLength(100);
            this.Property(t => t.MenuName).HasMaxLength(50).IsRequired();
            this.Property(t => t.MenuUrl).HasMaxLength(50);

        }
    }
}
