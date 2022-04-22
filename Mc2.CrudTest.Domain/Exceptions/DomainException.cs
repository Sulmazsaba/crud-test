using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message)
        {
            throw new Exception(message);
        }
    }
}
