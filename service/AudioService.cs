
using System;
using System.IO;
using System.Media;

namespace cd_CybersecurityAwarenessBott.service
{
    public class AudioService
    {
        public void PlayWelcomeGreeting()
        {
            string audioPath = Path.Combine(
                AppContext.BaseDirectory,
                "Audio",
                "welcome.wav"
            );

            if (File.Exists(audioPath))
            {
                using SoundPlayer player = new SoundPlayer(audioPath);
                player.PlaySync();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Voice greeting could not be found.");
                Console.ResetColor();
            }
        }
    }
}