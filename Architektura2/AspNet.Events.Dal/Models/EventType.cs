namespace AspNet.Events.Dal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
