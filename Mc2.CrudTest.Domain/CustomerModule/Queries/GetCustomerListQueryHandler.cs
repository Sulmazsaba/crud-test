using AutoMapper;
using Mc2.CrudTest.Domain.CustomerModule.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Queries
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();
            return (_mapper.Map<List<CustomerDto>>(customers));  

        }
    }
}
