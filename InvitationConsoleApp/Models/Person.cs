namespace InvitationConsoleApp.Models
{
    internal abstract class Person
    {
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string Surname { get; set; }
        public string SurnamePrefix { get; set; }
        //public Honorifics Honorific {get; set;}
        public Genders Gender { get; set; }
        public virtual string FullName {
            get {
                return $"{FirstName} {SurnamePrefix} {Surname}";
            }
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Person ()
        {

        }
        public Person (string firstName, string surnamePrefix, string surname)
        {
            FirstName = firstName;
            SurnamePrefix = surnamePrefix;
            Surname = surname;
        }
    }
}