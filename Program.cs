using cd_CybersecurityAwarenessBott.Models;
using cd_CybersecurityAwarenessBott.service;
using cd_CybersecurityAwarenessBott.UI;

Console.Title = "Cybersecurity Awareness Bot";
AudioService audio = new AudioService();
audio.PlayWelcomeGreeting();

ConsoleUI ui = new ConsoleUI();
ChatbotService chatbot = new ChatbotService();
UserProfile user = new UserProfile();

ui.ShowLogo();

ui.ShowSection("USER INFORMATION");

Console.ForegroundColor = ConsoleColor.White;
Console.Write("Please enter your name: ");
Console.ResetColor();

string? enteredName = Console.ReadLine();

while (string.IsNullOrWhiteSpace(enteredName))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Name cannot be empty. Please enter your name: ");
    Console.ResetColor();

    enteredName = Console.ReadLine();
}

user.Name = enteredName.Trim();

ui.ShowWelcome(user.Name);

ui.ShowSection("CYBERSECURITY CHAT");

Console.WriteLine("You can ask questions such as:");
Console.WriteLine("- How are you?");
Console.WriteLine("- What is your purpose?");
Console.WriteLine("- What can I ask you about?");
Console.WriteLine("- How can I create a safe password?");
Console.WriteLine("- What is phishing?");
Console.WriteLine("- How do I identify a suspicious link?");
Console.WriteLine("- How can I browse safely?");
Console.WriteLine();
Console.WriteLine("Type 'exit' when you want to leave.");
Console.WriteLine();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{user.Name}: ");
    Console.ResetColor();

    string? input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter a question so I can help you.");
        Console.ResetColor();
        continue;
    }

    if (input.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    string response = chatbot.GetResponse(input, user.Name);

    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Bot: ");
    Console.ResetColor();

    ui.TypeMessage(response);
}

ui.ShowGoodbye();






