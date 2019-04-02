using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Poker.Core.Entities;
using Poker.Core.Interfaces;
using Poker.Core.Repositories;
using Poker.Core.Services;
using System;

namespace Poker.Core.Tests.Helpers
{
    public class DependencyInjector
    {
        private static IServiceProvider _serviceProvider;

        public DependencyInjector()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            var builder = new ContainerBuilder();

            // register for all the repositories
            builder.RegisterType<Repository<Player>>().As<IRepository<Player>>();
            
            // Mock the database only
            builder.RegisterType<MockPockerDatabase>().As<IPockerDatabase>();

            // register for services
            builder.RegisterType<DealerService>().As<IDealerService>();
            builder.RegisterType<TwoCardsGameRule>().As<IGameRuleService>();

            var appContainer = builder.Build();
            _serviceProvider = new AutofacServiceProvider(appContainer);
        }

        public T ResolveService<T>()  
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
