using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.DomainService.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DomainService
{
    public static class DomainServicesRegistration
    {
        public static IServiceCollection AddDomainsService(this IServiceCollection services)
        {

            services.AddScoped<ICustomerDuplicateChecker, CustomerDuplicateChecker>();
            services.AddScoped<IEmailCustomerDuplicateChecker, EmailCustomerDuplicateChecker>();

            return services;
        }
    }
}
