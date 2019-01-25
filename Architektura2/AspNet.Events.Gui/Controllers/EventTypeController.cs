using AspNet.Events.Contract.Dto;
using AspNet.Events.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNET.GenericRepository.Controllers
{
    public class EventTypeController : Controller
    {
        private IEventService _eventService;
        public EventTypeController(IEventService eventService)
        {
            _eventService = eventService;
            _eventService.AddEventType(new EventTypeDto { Name = "Test" });
        }

        // GET: EventType
        public ActionResult Index()
        {
            return View();
        }
    }
}