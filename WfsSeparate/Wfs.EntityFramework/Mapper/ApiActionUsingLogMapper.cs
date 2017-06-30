using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wfs.Domain;

namespace Wfs.EntityFramework.Mapper
{
    public class ApiActionUsingLogMapper : EntityTypeConfiguration<ApiActionUsingLog>
    {
        public ApiActionUsingLogMapper()
        {
            this.Property(x=>x.ActionId).IsRequired();
            this.Property(x => x.BrowserInfo).HasMaxLength(512);
            this.Property(x => x.Ip).HasMaxLength(50).IsRequired();
            this.Property(x => x.UsingResult).HasMaxLength(256);
        }
    }
}
