using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }

        public CustomerUpdatorArgument ToCustomerUpdatorArgument()
        {
            return new CustomerUpdatorArgument
            {
                BankAccountNumber = BankAccountNumber,
                CustomerId = Id,
                DateOfBirth = DateOfBirth,
                PhoneNumber = PhoneNumber,
                Firstname = Firstname,
                Lastname = Lastname
            };
        }


    }
}
