using AutoMapper;
using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public class CustomerWriter : ICustomerWriter
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CustomerWriter(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper;
        }

        public async Task<CustomerDto> AddCustomer(AddCustomerCommand command)
        {
            var customerId = await _mediator.Send(command);

            var dto = _mapper.Map<CustomerDto>(command);
            dto.Id = customerId;

            return dto;
        }

        public async Task DeleteCustomer(DeleteCustomerCommand command)
        {
            await _mediator.Send(command);
        }

        public async Task UpdateCustomer(UpdateCustomerCommand command)
        {
            await _mediator.Send(command);
        }
    }
}
