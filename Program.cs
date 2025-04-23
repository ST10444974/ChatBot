using System;
using System.Media;
using System.Threading;
using System.IO;
using ChatBot;

namespace CybersecurityBotPart1
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Cybersecurity Awareness Bot";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false;

            AsciiArtDisplay.Show();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=========================================================================================");
            Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
            Console.WriteLine("=========================================================================================");
            Console.ResetColor();

            Audio.PlayWelcomeAudio();

            string name = UserInteraction.GetUserName();
            UserInteraction.WelcomeUser(name);

            bool running = true;
            while (running)
            {
                UserInteraction.DrawBorder();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{name}, ask me about cybersecurity (or 'exit'): ");
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a valid question.");
                    continue;
                }

                string response = CybersecurityResponder.GetResponse(input);
                Console.ForegroundColor = ConsoleColor.Cyan;
                TextEffects.TypeWriter(response, 50);

                if (input == "exit" ||input == "bye"|| input == "quit" ) running = false;
            }

            UserInteraction.Farewell();
        }
    }
}










   