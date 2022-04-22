using Mc2.CrudTest.Domain.Core;
using Mc2.CrudTest.Domain.CustomerModule.Factories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {


            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddScoped<IDomainEvent, DomainEventBase>();

            services.AddScoped<ICustomerFactory, CustomerFactory>();

            return services;
        }
    }
}
