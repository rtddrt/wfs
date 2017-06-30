using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Domain;
using Wfs.EntityFramework.Mapper;

namespace Wfs.EntityFramework.Context
{
    public class WfsContext : DbContext, IDbContext
    {
        public WfsContext()
            : base("Name=Default")
        {
            System.Data.Entity.Database.SetInitializer<WfsContext>(null);
        }

        public WfsContext(string nameString)
            : base(nameString)
        {
            System.Data.Entity.Database.SetInitializer<WfsContext>(null);
        }

        //TODO  在此处设置DbSet
        public IDbSet<SysAction> SysAction { get; set; }

        public IDbSet<SysMenu> SysMenu { get; set; }

        public IDbSet<SysRole> SysRole { get; set; }

        public IDbSet<SysRoleAction> SysRoleAction { get; set; }

        public IDbSet<SysUser> SysUser { get; set; }

        public IDbSet<SysUserInfo> SysUserInfo { get; set; }

        public IDbSet<SysUserRole> SysUserRole { get; set; }

        public IDbSet<ThirdClient> ThirdClient { get; set; }

        public IDbSet<ThirdClientAction> ThirdClientAction { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                     .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                     .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                      type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
