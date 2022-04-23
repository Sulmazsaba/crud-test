using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public System.Guid Id { get; set; }
    }
}
