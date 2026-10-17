
using System;
using System.Windows.Forms;

namespace CybersecurityAwarenessBot.GUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmCybersecurityBot());
        }
    }
}