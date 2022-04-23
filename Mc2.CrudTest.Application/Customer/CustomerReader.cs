using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public class CustomerReader : ICustomerReader
    {
        private readonly IMediator _mediator;

        public CustomerReader(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            return await _mediator.Send(new GetCustomerListQuery());
        }


        public async Task<CustomerDto> GetById(GetCustomerByIdQuery getCustomerByIdQuery)
        {
            return await _mediator.Send(getCustomerByIdQuery);
        }
    }
}
