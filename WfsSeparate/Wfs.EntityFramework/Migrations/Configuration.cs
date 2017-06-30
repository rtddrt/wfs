using Wfs.Domain;
using Wfs.EntityFramework.Migrations.Seed;

namespace Wfs.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Wfs.EntityFramework.Context.WfsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Wfs.EntityFramework.Context.WfsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            SystemSeed.InitSysRole(context);
            SystemSeed.InitSysUser(context);
            SystemSeed.InitSysUserRole(context);
            SystemSeed.InitSysMenu(context);
        }
    }
}
