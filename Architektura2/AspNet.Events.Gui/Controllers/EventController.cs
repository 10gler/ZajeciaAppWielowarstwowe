using AspNet.Events.Contract.Services;
using AspNET.GenericRepository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNET.GenericRepository.Controllers
{
    public class EventController : Controller
    {
        private IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: Event
        public ActionResult Index()
        {
            var events = _eventService.GetEvents().Select(n => new EventViewModel(n));
            return View(events);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create(EventViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var friends = Session["event"] as List<InvitedFriendViewModel> ?? new List<InvitedFriendViewModel>();
                    _eventService.AddEvent(new AspNet.Events.Contract.Dto.EventDto
                    {
                        Title = model.Title,
                        Description = model.Description,
                        InvitedFriends = friends.Select(n => new AspNet.Events.Contract.Dto.InvitedFriendDto
                        {
                            FirstName = n.FirstName,
                            LastName = n.LastName,
                            Email = n.Email
                        }).ToList() 
                    });
                    Session.Remove("event");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult InviteFriend([Bind(Include="Friend")] EventViewModel model)
        {
            try
            {        
                Session["event"] = Session["event"] ?? new List<InvitedFriendViewModel>();
                var friends = Session["event"] as List<InvitedFriendViewModel>;
                friends.Add(model.Friend);

                return PartialView("GetFriends", friends);
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]        
        public ActionResult GetFriends()
        {
            var invitedFriends = Session["event"] as List<InvitedFriendViewModel>;
            return PartialView(invitedFriends);
        }    
    }
}
