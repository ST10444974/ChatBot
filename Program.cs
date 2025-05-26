using System;
using System.Media;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// References used in this to help in this assignment:
// 1. National Institute of Standards and Technology (NIST) (2017) NIST Special Publication 800-63B: Digital Identity Guidelines. Available at: https://pages.nist.gov/800-63-3/sp800-63b.html (Accessed: 20 May 2025).
// 2. OWASP Foundation (2025) OWASP Top Ten Web Application Security Risks. Available at: https://owasp.org/www-project-top-ten/ (Accessed: 20 May 2025).
// 3. Microsoft (2024) Random Class (System). Available at: https://learn.microsoft.com/dotnet/api/system.random (Accessed: 24 May 2025).
// 4. Microsoft (2024) Regex Class (System.Text.RegularExpressions). Available at: https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex (Accessed: 24 May 2025).
// 5. Wikipedia contributors (2025) “Phishing,” Wikipedia, The Free Encyclopedia. Available at: https://en.wikipedia.org/wiki/Phishing (Accessed: 24 May 2025).
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