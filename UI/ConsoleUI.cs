using System;
using System.Collections.Generic;
using System.Text;

namespace cd_CybersecurityAwarenessBott.UI;
public class ConsoleUI
{
    public void ShowLogo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine();
        Console.WriteLine("==============================================================");
        Console.WriteLine("              CYBERSECURITY AWARENESS BOT");
        Console.WriteLine("==============================================================");
        Console.WriteLine("                    .--------.");
        Console.WriteLine("                   / .------. \\");
        Console.WriteLine("                  / /        \\ \\");
        Console.WriteLine("                  | |  LOCK  | |");
        Console.WriteLine("                  | |        | |");
        Console.WriteLine("                  |  \\______/  |");
        Console.WriteLine("                   \\__________/");
        Console.WriteLine("                    CYBER SAFE");
        Console.WriteLine("==============================================================");

        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowWelcome(string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine($"Welcome, {name}!");
        Console.WriteLine("I'm your Cybersecurity Awareness Assistant.");
        Console.WriteLine("Ask me questions about staying safe online.");

        Console.ResetColor();
        Console.WriteLine();
    }

    public void ShowSection(string title)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine();
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($" {title}");
        Console.WriteLine("--------------------------------------------------------------");

        Console.ResetColor();
    }

    public void TypeMessage(string message, int delay = 15)
    {
        foreach (char character in message)
        {
            Console.Write(character);
            Thread.Sleep(delay);
        }

        Console.WriteLine();
    }

    public void ShowGoodbye()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine();
        Console.WriteLine("==============================================================");
        Console.WriteLine("Thank you for using the Cybersecurity Awareness Bot!");
        Console.WriteLine("Stay alert. Stay informed. Stay cyber safe!");
        Console.WriteLine("==============================================================");
        Console.ResetColor();
    }
}
