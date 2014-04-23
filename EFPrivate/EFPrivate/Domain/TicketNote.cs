using System;

namespace EFPrivate.Domain
{
    public class TicketNote
    {
        private TicketNote() { }

        public TicketNote(string content, Ticket ticket)
        {
            Content = content;
            Created = DateTime.Now;
            Ticket = ticket;
            TicketId = ticket.TicketId;
        }

        public int TicketNoteId { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public Ticket Ticket { get; private set; }
        public int TicketId { get; private set; }
    }
}