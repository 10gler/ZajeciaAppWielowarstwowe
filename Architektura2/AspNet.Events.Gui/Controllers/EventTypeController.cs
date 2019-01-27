using AspNet.Events.Contract.Dto;
using AspNet.Events.Contract.Services;
using AspNET.GenericRepository.ViewModels;
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
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                _eventService.AddEventType(new EventTypeDto
                {
                    Name = model.Name
                });
                return RedirectToAction("Index");
            }
            return View(model);       
        }

        // GET: EventType
        public ActionResult Index()
        {
            var events = _eventService.GetEventTypes().Select(n => new EventTypeViewModel
            {
                Id = n.Id,
                Name = n.Name
            });

            return View(events);
        }
    }
}