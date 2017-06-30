using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class SysActionMapper : EntityTypeConfiguration<SysAction>
    {
        public SysActionMapper()
        {
            this.ToTable("SysAction");
            this.HasKey(t => new{t.Id,t.ControllerName,t.ActionName});
            this.Property(t => t.ControllerName).HasMaxLength(50).IsRequired();
            this.Property(t => t.ActionName).HasMaxLength(50).IsRequired();
            this.Property(t => t.Description).HasMaxLength(50);
            this.Property(t => t.NamedDescription).HasMaxLength(50);
        }
    }
}
