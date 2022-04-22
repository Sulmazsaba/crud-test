using Mc2.CrudTest.Domain.CustomerModule.Commands;
using System;

namespace Mc2.CrudTest.Presentation.Server.Requests
{
    public class UpdateCustomerRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }

        public UpdateCustomerCommand ToUpdateCustomerCommand(Guid customerId)
        {
            return new UpdateCustomerCommand
            {
                BankAccountNumber = BankAccountNumber,
                Id = customerId,
                DateOfBirth = DateOfBirth,
                PhoneNumber = PhoneNumber,
                Firstname = Firstname,
                Lastname = Lastname
            };
        }


    }
}
