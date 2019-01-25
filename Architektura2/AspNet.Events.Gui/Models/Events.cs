namespace AspNET.GenericRepository.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Events()
        {
            InvitedFriends = new HashSet<InvitedFriends>();
        }

        public int Id { get; set; }

        public int? EventType { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? Created { get; set; }

        public virtual EventTypes EventTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvitedFriends> InvitedFriends { get; set; }
    }
}
