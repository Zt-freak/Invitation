using System;
using System.Collections.Generic;
using System.Text;

namespace InvitationConsoleApp.Models
{
    class Invitation
    {
        public Invitee Receiver { get; set; }
        public InvitationEvent InviteEvent { get; set; }
        public string InviteText { get; set; }
    }
}
