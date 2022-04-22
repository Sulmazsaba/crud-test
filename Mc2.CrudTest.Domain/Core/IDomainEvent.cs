using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Core
{
    public interface IDomainEvent
    {

        Guid EventId { get; }

        Guid AggregateId { get; }
        long AggregateVersion { get; }
    }
}
