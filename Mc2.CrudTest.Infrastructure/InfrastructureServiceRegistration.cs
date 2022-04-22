using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Infrastructure.Persistence;
using Mc2.CrudTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Mc2DbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"))
                );

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;

        }
    }
}
