using BugTracker2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker2.Helpers
{
    public class TicketHelper : CommonHelper
    {     
        public List<Ticket> GetTicketsByPriority(string name)
        {
            return db.Tickets.Where(t => t.TicketPriority.Name == name).ToList();
        }

        public List<Ticket> GetTicketsByStatus(string name)
        {
            return db.Tickets.Where(t => t.TicketStatus.Name == name).ToList();
        }

        public List<Ticket> GetTicketsByType(string name)
        {
            return db.Tickets.Where(t => t.TicketType.Name == name).ToList();
        }

    }
}