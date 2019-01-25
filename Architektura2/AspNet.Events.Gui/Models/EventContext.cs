namespace AspNET.GenericRepository.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EventContext : DbContext
    {
        public EventContext()
            : base("name=EventsDatabase")
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<EventTypes> EventTypes { get; set; }
        public virtual DbSet<InvitedFriends> InvitedFriends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>()
                .HasMany(e => e.InvitedFriends)
                .WithOptional(e => e.Events)
                .HasForeignKey(e => e.EventId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<EventTypes>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.EventTypes)
                .HasForeignKey(e => e.EventType)
                .WillCascadeOnDelete();
        }
    }
}
