using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// References used in this to help in this assignment:
// 1. National Institute of Standards and Technology (NIST) (2017) NIST Special Publication 800-63B: Digital Identity Guidelines. Available at: https://pages.nist.gov/800-63-3/sp800-63b.html (Accessed: 20 May 2025).
// 2. OWASP Foundation (2025) OWASP Top Ten Web Application Security Risks. Available at: https://owasp.org/www-project-top-ten/ (Accessed: 20 May 2025).
// 3. Microsoft (2024) Random Class (System). Available at: https://learn.microsoft.com/dotnet/api/system.random (Accessed: 24 May 2025).
// 4. Microsoft (2024) Regex Class (System.Text.RegularExpressions). Available at: https://learn.microsoft.com/dotnet/api/system.text.regularexpressions.regex (Accessed: 24 May 2025).
// 5. Wikipedia contributors (2025) “Phishing,” Wikipedia, The Free Encyclopedia. Available at: https://en.wikipedia.org/wiki/Phishing (Accessed: 24 May 2025).
namespace ChatBot
{
    // Handles all user interaction and UI elements
    public static class UserInteraction
    {
        // UI color constants
        private const ConsoleColor BORDER_COLOR = ConsoleColor.DarkYellow;
        private const ConsoleColor USER_COLOR = ConsoleColor.Green;

        // Gets and validates user name input
        public static string GetUserName()
        {
            string userName;
            do
            {
                Console.ForegroundColor = USER_COLOR;
                Console.Write("\nPlease enter your name to begin: ");
                Console.ForegroundColor = ConsoleColor.White;
                userName = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please enter a valid name");
                }

            } while (string.IsNullOrEmpty(userName));

            return userName;
        }

        // Displays welcome message with user's name
        public static void WelcomeUser(string name)
        {
            Console.Clear();
            AsciiArtDisplay.Show();
            Console.ForegroundColor = USER_COLOR;
            TextEffects.TypeWriter($"Welcome, {name}!", 50);
            DrawBorder();
            TextEffects.TypeWriter("I'm your cybersecurity assistant here to help you:", 50);
            Console.WriteLine("- Stay safe online\n- Recognize security threats\n- Protect your digital identity");
            DrawBorder();
            Console.ResetColor();
        }

        // Draws a horizontal border line
        public static void DrawBorder()
        {
            Console.ForegroundColor = BORDER_COLOR;
            Console.WriteLine("==================================================================");
            Console.ResetColor();
        }

        // Displays exit message with security tips
        public static void Farewell()
        {
            Console.ForegroundColor = USER_COLOR;
            DrawBorder();
            TextEffects.TypeWriter("Stay safe online! Remember to:", 50);
            Console.WriteLine("- Keep software updated\n- Be skeptical of unsolicited requests\n- Backup important data");
            DrawBorder();
            Console.ResetColor();
        }
    }
}