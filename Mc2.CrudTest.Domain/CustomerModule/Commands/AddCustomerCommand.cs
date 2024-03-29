﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Commands
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public CustomerInitializerArgument ToInitializerArgument(Guid customerId)
        {
            return new CustomerInitializerArgument
            {
                CustomerId = customerId,
                BankAccountNumber = BankAccountNumber,
                DateOfBirth = DateOfBirth,
                PhoneNumber = PhoneNumber,
                Email = Email,
                Firstname = Firstname,
                Lastname = Lastname
            };
        }
    }
}
