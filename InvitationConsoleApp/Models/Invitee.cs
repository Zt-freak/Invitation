using System;
using System.Collections.Generic;
using System.Text;

namespace InvitationConsoleApp.Models
{
    internal class Invitee : Person
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
                return $"{getHonorific()} {Surname}, {FirstName} {SurnamePrefix}";
            }
        }

        public string getHonorific ()
        {
            switch (Gender)
            {
                case Genders.Male:
                    return "Sir";
                case Genders.Female:
                    return "Madame";
                default:
                    return "Sir/Madame";
            }
        }
    }
}
