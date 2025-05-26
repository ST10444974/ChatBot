using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    // Handles text animation effects
    public static class TextEffects
    {
        // Prints text with typewriter effect (character-by-character)
        // delay: milliseconds between characters (default 50ms)
        public static void TypeWriter(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Pause between characters
            }
            Console.WriteLine(); // Move to next line when done
        }
    }
}