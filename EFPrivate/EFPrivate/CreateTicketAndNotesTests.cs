using System;
using System.Diagnostics;
using System.Linq;
using EFPrivate.Data;
using EFPrivate.Domain;
using NUnit.Framework;

namespace EFPrivate
{
    public class CreateTicketAndNotesTests
    {
        [Test]
        public void CreateTicketNotesTest()
        {
            var context = new TicketsContext();

            var ticket = new Ticket();
            ticket.Title = "title";
            ticket.AddNewNote("t1");
            ticket.AddNewNote("t2");

            context.Tickets.Add(ticket);

            context.SaveChanges();
            int id = ticket.TicketId;

            context = new TicketsContext();
            context.Database.Log = Console.Write; // lazy loading. Remove "virtual" from _notes prop and test will fail.

            Ticket newticket = context.Tickets.Find(id);

            Assert.AreEqual(2, newticket.Notes.Count());
        }
    }
}
