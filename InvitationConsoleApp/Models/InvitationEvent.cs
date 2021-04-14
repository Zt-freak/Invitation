using System;
using System.Collections.Generic;
using System.Text;

namespace InvitationConsoleApp.Models
{
    class InvitationEvent
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public List<Invitee> invitees { get; set; }
    }
}
