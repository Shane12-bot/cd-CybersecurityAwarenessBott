
using System;
using System.IO;
using System.Media;

namespace CybersecurityAwarenessBot.GUI.Services
{
    public class AudioService
    {
        public void PlayWelcomeGreeting()
        {
            string audioPath = Path.Combine(
                AppContext.BaseDirectory,
                "Audio",
                "welcome.wav");

            if (!File.Exists(audioPath))
            {
                return;
            }

            try
            {
                using SoundPlayer player = new SoundPlayer(audioPath);
                player.Play();
            }
            catch
            {
                // The chatbot continues if audio playback fails.
            }
        }
    }
}
