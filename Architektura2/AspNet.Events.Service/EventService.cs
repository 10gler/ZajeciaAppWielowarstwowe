using AspNet.Events;
using AspNet.Events.Contract.Dto;
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
        private IRepository<Event> _eventRepository;
        private IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork, 
            IRepository<EventType> eventTypeRepository,
            IRepository<Event> eventRepository)
        {
            _unitOfWork = unitOfWork;
            _eventTypeRepository = eventTypeRepository;
            _eventRepository = eventRepository;
        }

        public void AddEvent(EventDto eventDto)
        {
            _eventRepository.Add(new Event
            {
                Created = DateTime.Now,
                Title = eventDto.Title,
                Description = eventDto.Description,
                InvitedFriends = eventDto.InvitedFriends.Select(n => new InvitedFriend
                {
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    Email = n.Email
                }).ToList()
            });
            _unitOfWork.Commit();
        }

        public void AddEventType(AspNet.Events.Contract.Dto.EventTypeDto eventTypeDto)
        {
            _eventTypeRepository.Add(new EventType { Name = eventTypeDto.Name });
            _unitOfWork.Commit();
        }

        public List<EventDtoResult> GetEvents()
        {
            return _eventRepository.GetAll(x=>x.InvitedFriends).Select(n => new EventDtoResult
            {
                Title = n.Title,
                Description = n.Description,
                InvitedFriends = n.InvitedFriends.Select(m => new InvitedFriendDto
                {
                    FirstName = m.FirstName,
                    LastName = m.LastName,
                    Email = m.Email
                }).ToList()
            }).ToList() ;
        }

        public IList<Contract.Dto.EventTypeDtoResult> GetEventTypes()
        {
            return _eventTypeRepository.GetAll().Select(n => new Contract.Dto.EventTypeDtoResult
            {
                Name = n.Name
            }).ToList();
        }
    }
}
