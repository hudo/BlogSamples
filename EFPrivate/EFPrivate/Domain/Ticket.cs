using System.Collections.Generic;

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

        protected virtual ICollection<TicketNote> _notes { get; set; }

        public IEnumerable<TicketNote> Notes
        {
            get { return _notes; }
        }

        public void AddNewNote(string content)
        {
            if(!string.IsNullOrWhiteSpace(content))
                _notes.Add(new TicketNote(content, this));
        }

    }
}