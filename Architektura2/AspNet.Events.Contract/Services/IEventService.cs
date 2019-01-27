using AspNet.Events.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Contract.Services
{
    public interface IEventService : IDependency
    {
        void AddEventType(EventTypeDto eventTypeDto);
        IList<EventTypeDtoResult> GetEventTypes();

        List<EventDtoResult> GetEvents();
        void AddEvent(EventDto eventDto);
        //...
    }
}
