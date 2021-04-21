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

            var sendOr = ContactMethod.Email | ContactMethod.WhatsApp;
            Console.WriteLine((int)sendOr);

            var sendAnd = ContactMethod.Email & ContactMethod.WhatsApp;
            Console.WriteLine((int)sendAnd);

            Organizer eventOrganizer = new Organizer();
            eventOrganizer.FirstName = GetUserInput("de voornaam van de organisator");
            eventOrganizer.SurnamePrefix = GetUserInput("de tussenvoegsels van de organisator", false);
            eventOrganizer.Surname = GetUserInput("de achternaam van de organisator");
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
                tempInvitee.FirstName = GetUserInput("de naam van de genodigde (<ENTER> om te beëindigen)", false, "string");
                if (!string.IsNullOrWhiteSpace(tempInvitee.FirstName))
                {
                    tempInvitee.SurnamePrefix = GetUserInput("de tussenvoegsels van de genodigde", false);
                    tempInvitee.Surname = GetUserInput("de achternaam van de genodigde");
                    tempInvitee.Honorific = GetUserInput("de aanhef van de genodigde", "honorific");
                    ContactMethod contactMethod = GetUserInput("De contactmethode voor de genodigde", "contact");
                    switch(contactMethod)
                    {
                        case ContactMethod.Email:
                            tempInvitee.Email = GetUserInput("het e-mailadres van de genodigde");
                            break;
                        case ContactMethod.Mail:
                            break;
                        case ContactMethod.Phone:
                            tempInvitee.PhoneNumber = GetUserInput("het telefoonnummer van de genodigde");
                            break;
                        case ContactMethod.WhatsApp:
                            tempInvitee.PhoneNumber = GetUserInput("het telefoonnummer van de genodigde");
                            break;
                    }
                    inviteEvent.invitees.Add(tempInvitee);
                }
            }
            while (!string.IsNullOrWhiteSpace(tempInvitee.FirstName));

            StringBuilder EventDetailsStringBuilder = new StringBuilder();
            EventDetailsStringBuilder.Append("De activiteit ");
            EventDetailsStringBuilder.Append(inviteEvent.Title);
            EventDetailsStringBuilder.Append(", op ");
            EventDetailsStringBuilder.Append(inviteEvent.Date.ToString("yyyy-MM-dd"));
            EventDetailsStringBuilder.Append(", wordt georganiseerd door ");
            EventDetailsStringBuilder.Append(eventOrganizer.FullName);
            EventDetailsStringBuilder.Append(" met het e-mailadres ");
            EventDetailsStringBuilder.Append(eventOrganizer.Email);

            Console.WriteLine(EventDetailsStringBuilder.ToString());

            if (inviteEvent.Description.Length > 0)
            {
                Console.WriteLine($"De beschrijving van het evenement is: {inviteEvent.Description}\n");
            }

            for (int i = 0; i < inviteEvent.invitees.Count; i++)
            {
                Console.WriteLine($"naam van genodigde {i + 1}/{inviteEvent.invitees.Count}: {inviteEvent.invitees[i].FullName}");
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
                    case "honorific":
                        Honorifics tempHonorific;
                        parseSuccess = Enum.TryParse(input, out tempHonorific);
                        output = tempHonorific;
                        break;
                    case "contact":
                        ContactMethod tempContactMethod;
                        parseSuccess = Enum.TryParse(input, out tempContactMethod);
                        output = tempContactMethod;
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
