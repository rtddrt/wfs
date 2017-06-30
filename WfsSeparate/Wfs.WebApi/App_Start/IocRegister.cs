using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using EntityFramework.DbContextScope;
using EntityFramework.DbContextScope.Interfaces;
using Wfs.Application;
using Wfs.Core;
using Wfs.DataCache.Base;
using Wfs.Domain.IRepositories;
using Wfs.EntityFramework;

namespace Wfs.WebApi
{
    /// <summary>
    /// Autofac自动注入
    /// </summary>
    public static class IocRegister
    {
        private static IContainer _container;
        public static void InitAutofac()
        {
            var builder = new ContainerBuilder();
            //注册缓存类
            builder.RegisterType(typeof(RedisHelper)).SingleInstance();
            //注册IAmbientDbContextLocator
            builder.RegisterType<AmbientDbContextLocator>().As<IAmbientDbContextLocator>();
            //注册 IDbContextScopeFactory
            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
            //注册数据库基础操作和工作单元
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IRepository<>));
            //builder.RegisterType(typeof(UnitWork)).As(typeof(IUnitWork));
            //注册缓存
            builder.RegisterGeneric(typeof(BaseCacheRepostitory<>)).As(typeof(IBaseCacheRepository<>));
            //注册Application层
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(BaseApplication)))
                .Where(x => x.Namespace == "Wfs.Application");

            //自动注册所有仓储接口和仓储实现
            var baseType = typeof(IDependency);
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray())
                   .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                   .AsImplementedInterfaces().InstancePerLifetimeScope();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // Set the dependency resolver to be Autofac.
            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }

        public static T GetType<T>()
        {
            return _container.Resolve<T>();
        }
    }
}