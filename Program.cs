using System;
using System.Diagnostics;
using System.Media;
using System.Runtime.Versioning;
using System.Text;

namespace WavPlayer
{
    
    partial class Program

    {
        
        
        static void Main(string[] args)

        {
            DisplayAsciiArt();

            // ✅ Then, Play the voice greeting (if you're on Windows)
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

            // Play the voice greeting
            PlayVoiceGreeting();

            Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        }
        [SupportedOSPlatform("windows")]
        static void PlayVoiceGreeting()

        {
            try
            {
                // Load and play the WAV file
                SoundPlayer player = new SoundPlayer(@"greeting.wav");
                player.PlaySync();// Play synchronously

            }
            catch (Exception e)
            {
                Console.WriteLine("Error playing audio: " + e.Message);
            }
        }
            static void DisplayAsciiArt()  
            {
            string asciiArt = @"
      SSSSSS  EEEEEEE  CCCCC  U     U  RRRRRR   III  TTTTTTT  Y     Y  
     S        E        C      U     U  R     R   I     T      Y   Y    
      SSSSSS  EEEEE    C      U     U  RRRRRR    I     T       Y Y     
           S  E        C      U     U  R   R     I     T        Y      
      SSSSSS  EEEEEEE  CCCCC   UUUUU   R    RR  III    T        Y      
    ";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(asciiArt);
            Console.ResetColor();
        }

            static void RunResponseSystem()
            {
                while (true)
                {
                    Console.WriteLine("\nYou can ask me questions like:");
                    Console.WriteLine("- How are you?");
                    Console.WriteLine("- What's your purpose?");
                    Console.WriteLine("- What can I ask you about?");
                    Console.WriteLine("- Type 'exit' to quit.");

                    Console.Write("\nAsk your question: ");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "exit")
                    {
                        Console.WriteLine("Goodbye! Stay safe online.");
                        break;
                    }

                    switch (userInput)
                    {
                        case "how are you?":
                            Console.WriteLine("I'm just a program, but I'm here to assist you!");
                            break;
                        case "what's your purpose?":
                            Console.WriteLine("My purpose is to help you learn about cybersecurity awareness.");
                            break;
                        case "what can i ask you about?":
                            Console.WriteLine("You can ask me general questions about cybersecurity and how to stay safe online.");
                            break;
                        default:
                            Console.WriteLine("I'm sorry, I don't have a response for that yet.");
                            break;
                    }
                }
            }
        
        private static string GetDebuggerDisplay()
        {
            return "WavPlayer Program Class";
        }  

    }  
}  



