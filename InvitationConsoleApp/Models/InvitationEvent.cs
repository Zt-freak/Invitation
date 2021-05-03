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
        public List<Invitee> Invitees { get; set; }
        public List<Organizer> Organizers { get; set; }

        public InvitationEvent ()
        {

        }
        public InvitationEvent (Organizer organizer)
        {
            Organizers = new List<Organizer>
            {
                organizer
            };
        }

        public InvitationEvent(List<Organizer> organizerList)
        {
            Organizers = organizerList;
        }
    }
}
