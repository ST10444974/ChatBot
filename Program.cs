using System;
using System.Media;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;



namespace ChatBot
{
    class Program
    {
        static void Main()
        {
            var context = new ConversationContext();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            AsciiArtDisplay.Show();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            Console.WriteLine("=========================================================================================");
            Console.ResetColor();

            Audio.PlayWelcomeAudio();
            var name = UserInteraction.GetUserName();
            UserInteraction.WelcomeUser(name);

            bool running = true;
            while (running)
            {
                UserInteraction.DrawBorder();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{name}, ask me about cybersecurity (or 'exit'): ");
                Console.ForegroundColor = ConsoleColor.Green;

                var input = Console.ReadLine()?.Trim() ?? "";

                // Exit commands
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase)
                    || input.Equals("quit", StringComparison.OrdinalIgnoreCase)
                    || input.Equals("bye", StringComparison.OrdinalIgnoreCase))
                {
                    running = false;
                    continue;
                }

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter something to continue.");
                    continue;
                }

                string response;
                try
                {
                    // Delegate to responder; it manages follow-ups and unknowns
                    response = CybersecurityResponder.GetResponse(input, context);
                }
                catch (Exception ex)
                {
                    // Fallback for any unexpected errors
                    response = "Oops—something went wrong on my end. Can you try rephrasing?";
                    // (Optionally log ex.Message to a file or console for debugging)
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                TextEffects.TypeWriter(response, 30);
            }

            UserInteraction.Farewell();
        }
    }
}