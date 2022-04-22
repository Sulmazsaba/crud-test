using Mc2.CrudTest.Domain.Core;
using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule
{
    public class Customer : EntityBase
    {
        private Customer()
        {

        }
        public Customer(CustomerInitializerArgument initilizer)
        {
            Id = Guid.NewGuid();
            Firstname = initilizer.Firstname;
            Lastname = initilizer.Lastname;
            DateOfBirth = initilizer.DateOfBirth;
            PhoneNumber = initilizer.PhoneNumber;
            Email = initilizer.Email;
            BankAccountNumber = initilizer.BankAccountNumber;

            RaiseEvent(new CustomerCreatedEvent(Id));
        }

        public Guid Id { get; init; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; init; }
        public string BankAccountNumber { get; private set; }

        public void CheckIfEmailIsValid(string email, IEmailCustomerDuplicateChecker duplicateChecker)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (!Regex.IsMatch(email,
                       @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                       RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    throw new DomainException("Email is not valid");

                if (duplicateChecker.IsEmailCustomerDuplicate(email, Id))
                    throw new DomainException("Email is duplicated");


            }
        }

        public void CheckIfPhoneNumberIsValid(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                if (!Regex.IsMatch(phoneNumber,
                      @"^09[0|1|2|3][0-9]{8}$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                    throw new DomainException("Monile is not valid");



            }
        }


        public void UpdateValues(CustomerUpdatorArgument updator )
        {
            CheckIfPhoneNumberIsValid(updator.PhoneNumber);

            Firstname = updator.Firstname;
            Lastname = updator.Lastname;
            DateOfBirth = updator.DateOfBirth;
            PhoneNumber = updator.PhoneNumber;
            BankAccountNumber = updator.BankAccountNumber;


        }
    }
}
