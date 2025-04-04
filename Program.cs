using System;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.Versioning; // os compatibility
using System.Text;
using System.IO; // Needed for Path
using System.Drawing.Imaging; // Needed for Bitmap;

namespace WavPlayer
{
    partial class Program
    {
        static void Main(string[] args)
        {
            DisplayAsciiArt();

            if (OperatingSystem.IsWindows())
            {
                PlayVoiceGreeting();
                Console.WriteLine("Welcome to the cybersecurity awareness bot");
            }
            else
            {
                Console.WriteLine("Voice greeting is only available on Windows.");
            }

            RunResponseSystem();

            Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot!");
        }

        [SupportedOSPlatform("windows")]
        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer(@"greeting.wav");
                player.PlaySync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error playing audio: " + e.Message);
            }
        }

        static void DisplayAsciiArt()
        {
            try
            {
                string fullLocation = AppDomain.CurrentDomain.BaseDirectory;
                string newLocation = Path.GetFullPath(Path.Combine(fullLocation, @"..\..\..\"));
                string fullPath = Path.Combine(newLocation, "logo.jpg");

                if (!File.Exists(fullPath))
                {
                    Console.WriteLine("Error: Image file 'logo.jpg' not found at " + fullPath);
                    return;
                }

                Bitmap image = new Bitmap(fullPath);
                image = new Bitmap(image, new Size(100, 60));

                for (int height = 0; height < image.Height; height++)
                {
                    for (int width = 0; width < image.Width; width++)
                    {
                        Color pixelColor = image.GetPixel(width, height);
                        int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                        char asciiChar = gray > 200 ? '-' : gray > 150 ? '*' : gray > 100 ? 'o' : gray > 50 ? '#' : '@';
                        Console.Write(asciiChar);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error displaying ASCII art: " + ex.Message);
            }
        }

        static void RunResponseSystem()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine("Hey " + userName + ", welcome to ChatBot!");

            // Dictionary to hold keyword groups and corresponding responses
            var responses = new (string[] Keywords, string Response)[]
            {
                (new[] { "how", "are", "you" }, "I'm just a program, but I'm here to assist you!"),
                (new[] { "purpose", "why", "exist" }, "My purpose is to help you learn about cybersecurity awareness."),
                (new[] { "questions", "can", "ask", "about" }, "You can ask me general questions about cybersecurity and how to stay safe online."),
                (new[] { "cybersecurity", "define", "what" }, "Cybersecurity is the practice of protecting systems, networks, and programs from digital attacks."),
                (new[] { "safe", "stay", "online" }, "To stay safe online, use strong passwords, avoid clicking on suspicious links, and keep your software up to date."),
                (new[] { "phishing", "explain", "what" }, "Phishing is a type of social engineering attack used to steal user data by pretending to be a trustworthy entity.")
            };

            while (true)
            {
                Console.WriteLine("\nYou can ask me anything about cybersecurity or type 'exit' to quit.");

                Console.Write("\nAsk your question: ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "exit")
                {
                    Console.WriteLine("Goodbye! Stay safe online.");
                    break;
                }

                bool foundResponse = false;

                foreach (var (keywords, response) in responses)
                {
                    // Check if any of the keywords appear in the user's question
                    foreach (var keyword in keywords)
                    {
                        if (userInput.Contains(keyword))
                        {
                            Console.WriteLine(response);
                            foundResponse = true;
                            break;
                        }
                    }

                    if (foundResponse) break; // Exit loop if a response was found
                }

                if (!foundResponse)
                {
                    Console.WriteLine("I'm sorry, I don't have a response for that yet.");
                }
            }
        }
    }
}
