using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.Persistence.EventStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Persistence
{
    internal class EventDataRepository
    {
        private readonly List<EventData> eventDatas = new List<EventData>();
        public EventDataRepository()
        {
            var id = Guid.NewGuid();
            eventDatas.Add(new EventData
            {
                Id = 1,
                EntityType = nameof(Customer),
                EventType = nameof(CustomerCreatedEvent),
                EntityId = id,
                EventSerializedData = JsonConvert.SerializeObject(new CustomerCreatedEvent
                {

                    Email = "ar@gmail.com",
                    
                    Firstname = "Alireza",
                    Lastname = "Oroumand",
                    //EventId = id,
                    
                })

            });
            //eventDatas.Add(new EventData
            //{
            //    EventDataId = 2,
            //    EntityType = nameof(Person),
            //    EventType = nameof(PersonEmailUpdated),
            //    EntityId = 1,
            //    EventSerializedData = JsonConvert.SerializeObject(new PersonEmailUpdated
            //    {
            //        Email = "oroumand@gmail.com",
            //    })

            //});
            //eventDatas.Add(new EventData
            //{
            //    EventDataId = 3,
            //    EntityType = nameof(Person),
            //    EventType = nameof(PersonCreated),
            //    EntityId = 2,
            //    EventSerializedData = JsonConvert.SerializeObject(new PersonCreated
            //    {
            //        Email = "lotfi@gmail.com",
            //        FirstName = "Mohammad",
            //        LastName = "Lotfi",
            //        Id = 2
            //    })

            //});
        }
        public List<EventData> GetEventDatas(string entityType, int entityId)
        {
            List<EventData> result = eventDatas.Where(c => c.EntityType == entityType && c.Id == entityId).ToList();
            return result;
        }
    }
}
