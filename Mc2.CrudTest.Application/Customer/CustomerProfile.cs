using AutoMapper;
using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Mc2.CrudTest.Application.Customer
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {

            CreateMap<AddCustomerCommand, CustomerDto>().ReverseMap();
            CreateMap<Domain.CustomerModule.Customer, CustomerDto>().ReverseMap();
        }
    }
}
