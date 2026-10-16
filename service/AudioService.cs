
using System;
using System.Diagnostics;
using System.IO;

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
                return;

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = "-NoProfile -Command \"(New-Object System.Media.SoundPlayer '" +
                                audioPath.Replace("'", "''") +
                                "').PlaySync()\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
            }
            catch
            {
                // Continue running if audio playback is unavailable.
            }
        }
    }
}
