using Data.Repositories.TaskManagement;
using Domain.Entities.Enums.Queries;
using Domain.Interfaces.TaskManagement;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Data;
using Domain;

namespace IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssemblyOf<DataAssembly>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            .FromAssemblyOf<DomainAssembly>()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsSelfWithInterfaces()
            .WithTransientLifetime()
            );

            var domainAssembly = typeof(EnumExampleQuery).GetTypeInfo().Assembly;

            services.AddMediatR(new Assembly[]
            {
                domainAssembly
            });

            services.AddScoped<ITaskManagementRepository, TaskManagementRepository>();
        }
    }
}
