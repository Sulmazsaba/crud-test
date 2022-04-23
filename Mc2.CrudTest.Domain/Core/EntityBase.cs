using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Core
{
    public abstract class EntityBase
    {
        private readonly List<IDomainEvent> _uncommitedEvents = new List<IDomainEvent>();
        public int Version { get; internal set; }


        protected void ClearUncommittedEvents()
        {
            _uncommitedEvents.Clear();
        }
        protected void RaiseEvent<TEvent>(TEvent @event) where TEvent : DomainEventBase
        {
            _uncommitedEvents.Add(@event);
        }
        public IEnumerable<IDomainEvent> GetUncommittedEvents() => _uncommitedEvents;



    }
}
