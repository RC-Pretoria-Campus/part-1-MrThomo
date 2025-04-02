using System;
using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Threading;
using System.Xml.Linq;

using System.Speech.Synthesis;
using System.Net.Http.Headers;
namespace ChatbotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Play the voice greeting
            PlayVoiceGreeting();

            // Display ASCII art (Cybersecurity Awareness Bot logo)
            DisplayAsciiLogo();

            // Greet the user and ask for their name
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("You didn't enter a name. Please try again.");
                return;
            }
            Console.WriteLine($"Hello, {userName}! Welcome to the Cybersecurity Awareness Bot!");

            // Simulate typing effect and ask user about how they need help
            TypeText("I am here to help you stay safe online by providing some cybersecurity tips...");

            // Respond to basic user queries
            RespondToQueries();

            // Example input validation handling
            InputValidation();
        }

        // Method to play the voice greeting when the chatbot starts
        static void PlayVoiceGreeting()
        {
            try
            {
                SpeechSynthesizer synth = new SpeechSynthesizer();
                Console.WriteLine("Welcome to the Cybersecurity Awareness chatbot!");
                synth.Speak("Welcome to the Cybersecurity Awareness chatbot!, Ask me anything about online safety.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the voice greeting: " + ex.Message);
            }
        }

        // Method to display the ASCII logo or art of the chatbot
        static void DisplayAsciiLogo()
        {
            Console.WriteLine(@"
  _____ _               _____                        
 / ____| |             / ____|                       
| |    | |_   _  ___  | |     ___   ___  __ _ _ __  
| |    | | | | |/ _ \ | |    / _ \ / _ \/ _` | '_ \ 
| |____| | |_| |  __/ | |___| (_) |  __/ (_| | | | |
 \_____|_|\__,_|\___|  \_____\___/ \___|\__,_|_| |_| 
");
        }

        // Method to simulate typing effect
        static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Simulate typing delay
            }
            Console.WriteLine();
        }

        // Method to respond to user queries about the chatbot's purpose
        static void RespondToQueries()
        {
            Console.WriteLine("Ask me anything about cybersecurity. Type 'exit' to quit.");
            string input;
            while ((input = Console.ReadLine().ToLower()) != "exit")
            {
                if (input == "how are you?")
                {
                    Console.WriteLine("I'm doing well, thank you for asking!");
                }
                else if (input == "what's your purpose?")
                {
                    Console.WriteLine("My purpose is to help you stay safe online by providing cybersecurity tips and answering your questions.");
                }
                else if (input == "what can I ask you about?")
                {
                    Console.WriteLine("You can ask me about topics like password safety, phishing, and safe browsing.");
                }
                else
                {
                    Console.WriteLine("I didn't quite understand that. Could you rephrase?");
                }
            }
        }

        // Method to handle input validation and guide the user if no valid input is entered
        static void InputValidation()
        {
            Console.Write("Please type a question: ");
            string userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("You didn't enter anything. Please type a valid question.");
            }
            else
            {
                Console.WriteLine("Thank you for your input! Now, how else can I help you?");
            }
        }
    }
}