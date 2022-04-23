using Mc2.CrudTest.Domain.CustomerModule;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Persistence
{
    public class DbContextSeed
    {
        public static async Task SeedAsync(Mc2DbContext context, ILogger<DbContextSeed> logger)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(GetPreconfiguredCustomers());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(Mc2DbContext).Name);
            }
        }

        private static IEnumerable<Customer> GetPreconfiguredCustomers()
        {
            var initializer = new CustomerInitializerArgument
            {
                CustomerId = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Snow",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Email = "JohnSnow@gmail.com",
                BankAccountNumber = "122233",
                PhoneNumber = "234234234"
            };

            return new List<Customer>
            {
                new Customer(initializer) 
            };
        }
    }
}

