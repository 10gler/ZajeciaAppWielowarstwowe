namespace AspNet.Events.Dal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public Event()
        {
            InvitedFriends = new HashSet<InvitedFriend>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Created { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual ICollection<InvitedFriend> InvitedFriends { get; set; }
    }
}
