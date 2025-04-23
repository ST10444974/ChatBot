using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    public static class Audio
    {
        private const string WELCOME_AUDIO_FILE = "./AI_VOICE_INTRO.wav";

        public static void PlayWelcomeAudio()
        {
            try
            {
                if (File.Exists(WELCOME_AUDIO_FILE))
                {
                    using (var player = new SoundPlayer(WELCOME_AUDIO_FILE))
                    {
                        player.Play();
                        Thread.Sleep(4000);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Note: Welcome audio file not found");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Audio Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}