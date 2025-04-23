using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChatBot
{
    /*   
     * Handles audio playback functionality for the chatbot.
     * Uses System.Media.SoundPlayer for WAV file playback.
     */

    public static class Audio
    {
        // Constants
        private const string WELCOME_AUDIO_FILE = "./AI_VOICE_INTRO.wav";  // Relative path to audio file

        /*
         * Plays the welcome audio clip (WAV format).
         * - Checks for file existence
         * - Handles playback errors gracefully
         * - Provides user feedback if audio is unavailable
         */

        public static void PlayWelcomeAudio()
        {
            try
            {
                // Verify audio file exists before attempting playback
                if (File.Exists(WELCOME_AUDIO_FILE))
                {
                    // Using block ensures SoundPlayer resources are properly disposed
                    using (var player = new SoundPlayer(WELCOME_AUDIO_FILE))
                    {
                        player.Play();  // Non-blocking asynchronous playback
                        Thread.Sleep(5000);  // Allow 5 seconds for audio to play
                    }
                }
                else
                {
                    // Visual warning for missing file (non-critical error)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Note: Welcome audio file not found");
                    Console.ResetColor();
                }
            }
            catch (Exception ex)  // Catch all potential audio exceptions
            {
                // Error handling for:
                // - File access issues
                // - Corrupted audio files
                // - Sound device problems
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Audio Error: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}