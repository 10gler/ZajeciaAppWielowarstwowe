using AspNet.Events.Contract.Services;
using AspNet.Events.Dal;
using AspNet.Events.Dal.Repository;
using AspNet.Events.Service;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Resolver
{
    public class ResolverModule : Autofac.Module
    {      
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(RepositoryBase<>)).As(typeof(IRepository<>));

            var serviceAssembly = typeof(AspNet.Events.Service.EventService).Assembly; //or Assembly.GetAssembly(typeof(AspNet.Events.Service.EventService));
            var serviceTypes = serviceAssembly.GetTypes().Where(n => n.IsClass && typeof(IDependency).IsAssignableFrom(n)).ToList();
            foreach (var serviceType in serviceTypes)
            {
                var i = serviceType.GetInterfaces().First();
                builder.RegisterType(serviceType).As(i);
            }

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            //Pytania do IBL:
            /*
             * Po co IDependecy dla IUnitOfWork?
             * Po co rejestracja w GUI? (poc o IDependecy w Cmmon)
             * Po co ISingletonDepenedency?
             * Uwagi:
             * Fajnie że IUnitOfWork w DAL
             * InstancePerDependency() - by default (When you resolve a component that is instance per dependency, you get a new one each time.)
             */
            //builder.RegisterType<EventService>().As<IEventService>().InstancePerRequest();
            //builder.RegisterType<EventsDataContext>().As<DbContext>().InstancePerLifetimeScope();
        }
    }
}

