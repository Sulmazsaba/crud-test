using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Persistence.EventStore
{
    internal class EventData
    {
        public int Id { get; set; }
        public string EntityType { get; set; }
        public string EventType { get; set; }

        public Guid EntityId { get; set; }

        public string EventSerializedData { get; set; }
    }
}
