using System;

namespace InvitationConsoleApp.Models
{
    [Flags]
    enum ContactMethod
    {
        Mail = 1,
        Email = 2,
        Phone = 4,
        WhatsApp = 8
    }
}

