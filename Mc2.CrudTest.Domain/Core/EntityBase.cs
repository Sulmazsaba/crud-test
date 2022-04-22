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
        //public  Guid Id { get; protected set; }
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


        public void LoadsFromHistory(IEnumerable<IDomainEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(IDomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        // push atomic aggregate changes to local history for further processing (EventStore.SaveEvents)
        private void ApplyChange(IDomainEvent @event, bool isNew)
        {
            //this.AsDynamic().Apply(@event);
            if (isNew) _uncommitedEvents.Add(@event);
        }

    }
}
