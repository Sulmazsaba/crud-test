using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Core
{
    public class DomainEventBase : IDomainEvent
    {
        protected DomainEventBase()
        {
            EventId = Guid.NewGuid();
        }

        protected DomainEventBase(Guid aggregateId) : this()
        {
            AggregateId = aggregateId;
        }

        protected DomainEventBase(Guid aggregateId, long aggregateVersion) : this(aggregateId)
        {
            AggregateVersion = aggregateVersion;
        }

        public Guid EventId { get; private set; }

        public Guid AggregateId { get; private set; }

        public long AggregateVersion { get; private set; }
    }
}
