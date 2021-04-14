namespace InvitationConsoleApp.Models
{
    internal class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Email { get; set; }
    }
}