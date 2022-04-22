using Mc2.CrudTest.Domain.CustomerModule.Factories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Commands
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerFactory _customerFactory;

        public AddCustomerCommandHandler(ICustomerRepository customerRepository,
            ICustomerFactory customerFactory)
        {
            _customerRepository = customerRepository;
            _customerFactory = customerFactory;
        }

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = _customerFactory.Create(request);


            await _customerRepository.AddAsync(customer);

            return customer.Id;
        }
    }
}
