using System;
using System.Collections.Generic;
using System.Text;

namespace InvitationConsoleApp.Models
{
    class Invitee : Person
    {
        private bool canAttend;
        public bool CanAttend
        {
            get { return canAttend; }
            set { canAttend = value; }
        }

        public override string FullName
        {
            get
            {
                return $"{Honorific.ToString()} {Surname}, {FirstName} {SurnamePrefix}";
            }
        }
    }
}
