using AspNet.Events.Contract.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNET.GenericRepository.ViewModels
{
    public class EventViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public InvitedFriendViewModel Friend { get; set; }

        public List<InvitedFriendViewModel> InvitedFriends { get; set; }

        public EventViewModel() {}

        public EventViewModel(EventDtoResult eventDtoResult)
        {
            Title = eventDtoResult.Title;
            Description = eventDtoResult.Description;
            if (eventDtoResult.InvitedFriends.Any())
            {
                InvitedFriends = eventDtoResult.InvitedFriends.Select(n => new InvitedFriendViewModel
                {
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    Email = n.Email
                }).ToList();
            }
        }
    }
}