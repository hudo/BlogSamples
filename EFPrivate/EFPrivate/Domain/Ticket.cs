using System;
using System.Collections.Generic;
using System.Linq;

namespace EFPrivate.Domain
{
    public class Ticket
    {
        public Ticket()
        {
            _notes = new List<TicketNote>();
        }

        public int TicketId { get; set; }
        public string Title { get; set; }
        public TicketStatus TicketStatus { get; private set; }

        protected virtual ICollection<TicketNote> _notes { get; set; }

        public IEnumerable<TicketNote> Notes
        {
            get { return _notes.ToList(); }
        }

        public void OpenTicket()
        {
            if (TicketStatus == TicketStatus.New)
                TicketStatus = TicketStatus.InProgress;
            else
                throw new Exception("Only new tickets can be opened");
        }

        public void CloseTicket()
        {
            if (TicketStatus == TicketStatus.InProgress)
                TicketStatus = TicketStatus.Closed;
            else
                throw new Exception("Only opened tickets can be closed");
        }
       
        public void AddNewNote(string content)
        {
            if(TicketStatus != TicketStatus.InProgress)
                throw new Exception("Can't add a note, ticket not in progress");

            if(!string.IsNullOrWhiteSpace(content))
                _notes.Add(new TicketNote(content, this));
        }

    }
}