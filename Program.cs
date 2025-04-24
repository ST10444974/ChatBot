using System;
using System.Media;       
using System.Threading;  
using System.IO;          

namespace ChatBot
{
    class Program
    {
        static void Main()
        {
            // Set up console appearance
            Console.OutputEncoding = System.Text.Encoding.UTF8;  // Support Unicode characters
            Console.CursorVisible = false;  // Hide the cursor for cleaner UI

            // Display ASCII image
            AsciiArtDisplay.Show();

            // Print welcome message with colored formatting
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            Console.WriteLine("=========================================================================================");
            Console.ResetColor();  // Reset to default console color

            // Play welcome audio
            Audio.PlayWelcomeAudio();

            // Get user's name and personalize welcome
            string name = UserInteraction.GetUserName();
            UserInteraction.WelcomeUser(name);

            // Main interaction loop
            bool running = true;
            while (running)
            {
                // Draw UI border and prompt user for input
                UserInteraction.DrawBorder();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{name}, ask me about cybersecurity (or 'exit'): ");
                Console.ForegroundColor = ConsoleColor.Green;

                // Get and process user input
                string input = Console.ReadLine()?.Trim().ToLower();  

                // Handle empty input
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a valid question.");
                    continue;  // Skip to next iteration
                }

                // Get appropriate response from the cybersecurity knowledge base
                string response = CybersecurityResponder.GetResponse(input);

                // Display response with typewriter effect
                Console.ForegroundColor = ConsoleColor.Cyan;
                TextEffects.TypeWriter(response, 50);  // 50ms delay between characters

                // Check for exit commands
                if (input == "exit" || input == "bye" || input == "quit")
                    running = false;
            }

            // Display farewell message when exiting
            UserInteraction.Farewell();
        }
    }
}






