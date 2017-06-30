using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class ThirdClientActionMapper : EntityTypeConfiguration<ThirdClientAction>
    {
        public ThirdClientActionMapper()
        {
            ToTable("ThirdClientAction");
            this.HasKey(x => x.Id);
            this.Property(x => x.ActionId).HasMaxLength(50).IsRequired();
            this.Property(x => x.ThirdClientId).IsRequired();
        }
    }
}
