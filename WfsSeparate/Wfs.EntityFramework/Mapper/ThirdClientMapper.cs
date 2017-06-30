using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class ThirdClientMapper : EntityTypeConfiguration<ThirdClient>
    {
        public ThirdClientMapper()
        {
            ToTable("ThirdClient");
            this.HasKey(x => x.Id);
            this.Property(x => x.ThirdClientName).HasMaxLength(100).IsRequired();
            this.Property(x => x.ThirdClientSecret).HasMaxLength(50).IsRequired();
            this.Property(x => x.ThirdClientUrl).HasMaxLength(100);
            this.Property(x => x.ThirdClientCode).HasMaxLength(50);
            this.Property(x => x.ThirdDescription).HasMaxLength(512);
        }
    }
}
