using AspNet.Events;
using AspNet.Events.Contract.Services;
using AspNet.Events.Dal;
using AspNet.Events.Dal.Models;
using AspNet.Events.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Events.Service
{
    public class EventService : IEventService
    {
        private IRepository<EventType> _eventTypeRepository;
        private IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork, IRepository<EventType> eventTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _eventTypeRepository = eventTypeRepository;
        }
        public void AddEventType(AspNet.Events.Contract.Dto.EventTypeDto eventTypeDto)
        {
            _eventTypeRepository.Add(new EventType { Name = eventTypeDto.Name });
            _unitOfWork.Commit();
        }

        public IList<Contract.Dto.EventTypeDtoResult> GetEventTypes()
        {
            throw new NotImplementedException();
        }
    }
}
