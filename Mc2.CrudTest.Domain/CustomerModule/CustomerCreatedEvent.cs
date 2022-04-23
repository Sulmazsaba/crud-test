using Mc2.CrudTest.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule
{
    public class CustomerCreatedEvent : DomainEventBase
    {
        public CustomerCreatedEvent() : base()
        {
        }

        public CustomerCreatedEvent(System.Guid aggregateId) : base(aggregateId)
        {

        }

        public CustomerCreatedEvent( string firstname, string lastname, DateTime dateOfBirth,
          string phoneNumber, string email, string bankAccountNumber)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
