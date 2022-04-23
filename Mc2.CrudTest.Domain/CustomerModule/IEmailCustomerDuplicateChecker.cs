﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule
{
    public interface IEmailCustomerDuplicateChecker
    {
        bool IsEmailCustomerDuplicate(string email, System.Guid customerId);

    }
}
