using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading;
using System.Speech.Synthesis;
using System.Media;

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
            string userName = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("You didn't enter a name. Please try again.");
                return;
            }

            Console.WriteLine($"\nHello, {userName}! Welcome to the Cybersecurity Awareness Bot!");
            TypeText("I am here to help you stay safe online by providing cybersecurity tips...");

            // Start conversation with question-answer feature
            StartConversation();
        }

        // Method to play the voice greeting from a WAV file or use TTS as fallback
        static void PlayVoiceGreeting()
        {
            try
            {
                string filePath = "Greeting(2).wav"; // wave audio 

                if (System.IO.File.Exists(filePath))
                {
                    using (SoundPlayer player = new SoundPlayer(filePath))
                    {
                        player.PlaySync(); // Play the sound synchronously
                    }
                }
                else
                {
                    Console.WriteLine("Audio file not found. Playing fallback Text-to-Speech greeting.");
                    SpeechSynthesizer synth = new SpeechSynthesizer();
                    synth.Speak("Welcome to the Cybersecurity Awareness chatbot! Ask me anything about online safety.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing the voice greeting: " + ex.Message);
            }
        }

        // Method to display ASCII logo
        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  _____ _               _____                        
 / ____| |             / ____|                       
| |    | |_   _  ___  | |     ___   ___  __ _ _ __  
| |    | | | | |/ _ \ | |    / _ \ / _ \/ _` | '_ \ 
| |____| | |_| |  __/ | |___| (_) |  __/ (_| | | | |
 \_____|_|\__,_|\___|  \_____\___/ \___|\__,_|_| |_|
");
            Console.ResetColor();
        }

        // Method to simulate a typing effect
        static void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }

        // Chatbot question-answer interaction
        static void StartConversation()
        {
            Dictionary<string, string> faq = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "What is phishing?", "Phishing is a cyber attack where scammers trick you into revealing personal information by pretending to be a trusted source, like a bank or social media site." },
                { "How can I create a strong password?", "A strong password should be at least 12 characters long, including uppercase letters, lowercase letters, numbers, and special characters (!@#$%^&*)." },
                { "Why is two-factor authentication important?", "Two-factor authentication (2FA) adds an extra layer of security by requiring a second step, like a code sent to your phone, making it harder for hackers to access your account." },
                { "What should I do if I receive a suspicious email?", "Do not click on any links or download attachments. Check the sender’s email address, and if it looks suspicious, report it as phishing and delete it." },
                { "What is malware?", "Malware is malicious software that is designed to harm your computer or steal your data. Examples include viruses, ransomware, spyware, and trojans." },
                { "How can I recognize a phishing attack?", "Phishing attacks often use urgent messages, spelling mistakes, fake links, and requests for personal information. Always verify links before clicking." },
                { "What is ransomware?", "Ransomware is a type of malware that encrypts your files and demands payment to unlock them. Never pay the ransom—report the attack and restore your files from a backup." },
                { "Why should I update my software regularly?", "Software updates fix security flaws and protect you from cyber threats. Hackers exploit outdated software to access devices." },
                { "What is a firewall?", "A firewall is a security system that blocks unauthorized access to or from a network, helping to protect your data from cyber threats." },
                { "How does social engineering work?", "Social engineering tricks people into giving away confidential information by pretending to be a trusted entity. Examples include phishing emails and fake phone calls." },
                { "What is identity theft?", "Identity theft happens when someone steals your personal details, like your ID or credit card number, to commit fraud." },
                { "How can I browse the internet safely?", "Use a secure browser, avoid public Wi-Fi for sensitive transactions, enable security settings, and never share private information on untrusted websites." },
                { "What is a VPN?", "A Virtual Private Network (VPN) encrypts your internet connection, keeping your online activities private and secure from hackers." },
                { "Why is it important to log out of accounts?", "Logging out of accounts prevents unauthorized access, especially if you’re using a shared or public computer." },
                { "What is spyware?", "Spyware is a type of malware that secretly collects information about your online activities without your permission." }
            };

            Console.WriteLine("\nYou can ask me any of the following cybersecurity questions:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var question in faq.Keys)
            {
                Console.WriteLine($"- {question}");
            }
            Console.ResetColor();
            Console.WriteLine("\nType your question exactly as listed above, or type 'exit' to quit.");

            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.Trim();

                if (userInput?.Equals("exit", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("\nChatbot: Thank you for using the Cybersecurity Awareness Bot. Stay safe online!");
                    break;
                }

                if (faq.TryGetValue(userInput, out string answer))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Chatbot: {answer}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nChatbot: I didn't understand that. Please ask one of the listed questions.");
                    Console.ResetColor();
                }
            }
        }
    }
}