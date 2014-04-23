using System.Data.Entity;
using EFPrivate.Domain;

namespace EFPrivate.Data
{
    public class TicketsContext : DbContext
    {
        public IDbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>().HasMany<Ticket, TicketNote>("_notes");
            modelBuilder.Entity<TicketNote>().ToTable("TicketNotes");

            base.OnModelCreating(modelBuilder);
        }
    }
}
