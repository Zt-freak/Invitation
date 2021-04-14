using InvitationConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvitationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Organizer eventOrganizer = new Organizer();
            eventOrganizer.Name = GetUserInput("de naam van de organisator");
            eventOrganizer.Email = GetUserInput("het e-mailadres van de organisator");

            InvitationEvent inviteEvent = new InvitationEvent();
            inviteEvent.Date = GetUserInput("de datum van het evenement", "date");
            inviteEvent.Title = GetUserInput("de naam van het evenement");
            inviteEvent.Description = GetUserInput("de beschrijving van het evenement", false);
            inviteEvent.invitees = new List<Invitee>();

            Invitee tempInvitee;
            do
            {
                tempInvitee = new Invitee();
                tempInvitee.Name = GetUserInput("de naam van de genodigde (<ENTER> om te beëindigen)", false, "string");
                if (!string.IsNullOrWhiteSpace(tempInvitee.Name))
                {
                    tempInvitee.Email = GetUserInput("het e-mailadres van de genodigde");
                    inviteEvent.invitees.Add(tempInvitee);
                }
            }
            while (!string.IsNullOrWhiteSpace(tempInvitee.Name));

            StringBuilder EventDetailsStringBuilder = new StringBuilder();
            EventDetailsStringBuilder.Append("De activiteit ");
            EventDetailsStringBuilder.Append(inviteEvent.Title);
            EventDetailsStringBuilder.Append(", op ");
            EventDetailsStringBuilder.Append(inviteEvent.Date.ToString("yyyy-MM-dd"));
            EventDetailsStringBuilder.Append(", wordt georganiseerd door ");
            EventDetailsStringBuilder.Append(eventOrganizer.Name);
            EventDetailsStringBuilder.Append(" met het e-mailadres ");
            EventDetailsStringBuilder.Append(eventOrganizer.Email);

            Console.WriteLine(EventDetailsStringBuilder.ToString());

            if (inviteEvent.Description.Length > 0)
            {
                Console.WriteLine($"De beschrijving van het evenement is: {inviteEvent.Description}\n");
            }

            for (int i = 0; i < inviteEvent.invitees.Count; i++)
            {
                Console.WriteLine($"naam van genodigde {i + 1}/{inviteEvent.invitees.Count}: {inviteEvent.invitees[i].Name}");
                Console.WriteLine($"email van genodigde {i + 1}/{inviteEvent.invitees.Count}: {inviteEvent.invitees[i].Email}");
            }

            Console.WriteLine("Press <ENTER> to exit.");
            Console.ReadLine();
        }

        private static dynamic GetUserInput(string description)
        {
            return GetUserInput(description, true, "string");
        }

        private static dynamic GetUserInput(string description, bool required)
        {
            return GetUserInput(description, required, "string");
        }

        private static dynamic GetUserInput(string description, string dataType)
        {
            return GetUserInput(description, true, dataType);
        }

        private static dynamic GetUserInput (string description, bool required, string dataType)
        {
            string input;

            string requiredName = "verplicht";
            if (!required)
            {
                requiredName = "optioneel";
            }

            bool parseSuccess = false;
            dynamic output;
            do
            {
                input = DisplayUserInputPrompt(description, requiredName, dataType);
                switch (dataType)
                {
                    case "int":
                    case "integer":
                        int tempInt;
                        parseSuccess = int.TryParse(input, out tempInt);
                        output = tempInt;
                        break;
                    case "date":
                        DateTime tempDate;
                        parseSuccess = DateTime.TryParse(input, out tempDate);
                        output = tempDate;
                        break;
                    case "string":
                    default:
                        parseSuccess = true;
                        output = input;
                        break;
                }
            }
            while (required && string.IsNullOrWhiteSpace(input) || !string.IsNullOrWhiteSpace(input) && !parseSuccess);

            return output;
        }

        private static string DisplayUserInputPrompt (string description, string requiredName, string dataType)
        {
            if (dataType == "date")
            {
                dataType = "yyyy-MM-dd";
            }
            Console.WriteLine($"Voer {description} in ({dataType}) ({requiredName}):");
            string input = Console.ReadLine();
            Console.Clear();
            return input;
        }
    }
}
