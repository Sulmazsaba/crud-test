using Mc2.CrudTest.Domain.CustomerModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Persistence
{
    public  class Mc2DbContext :  DbContext
    {
        public Mc2DbContext(DbContextOptions<Mc2DbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
