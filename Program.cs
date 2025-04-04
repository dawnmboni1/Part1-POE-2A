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

                foreach (var (keywords, response) in QuestionsAndResponses.Responses)
                {
                    int matches = 0;

                    foreach (var keyword in keywords)
                    {
                        if (userInput.Contains(keyword))
                        {
                            matches++;
                        }
                    }

                    if (matches >= keywords.Length / 2)
                    {
                        Console.WriteLine(response);
                        foundResponse = true;
                        break;
                    }
                }

                if (!foundResponse)
                {
                    Console.WriteLine("I'm sorry, I don't have a response for that yet.");
                }
            }
        }
    }
}
