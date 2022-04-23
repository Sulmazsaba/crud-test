using Mc2.CrudTest.Domain.CustomerModule.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerDuplicateChecker _customerDuplicateChecker;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, ICustomerDuplicateChecker customerDuplicateChecker)
        {
            _customerRepository = customerRepository;
            _customerDuplicateChecker = customerDuplicateChecker;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            _customerDuplicateChecker.CheckCustomerDuplicated(request.Id, request.Firstname, request.Lastname, request.DateOfBirth);

            customer.UpdateValues(request.ToCustomerUpdatorArgument());

            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}
