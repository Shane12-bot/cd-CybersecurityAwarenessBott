using System;
using System.Collections.Generic;
using System.Text;

namespace cd_CybersecurityAwarenessBott.service;
public class ChatbotService
{
    public string GetResponse(string input, string userName)
    {
        string message = input.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(message))
        {
            return "I didn't quite understand that. Please enter a question.";
        }

        if (message.Contains("how are you"))
        {
            return $"I'm doing well, {userName}! I'm ready to help you stay safer online.";
        }

        if (message.Contains("purpose") || message.Contains("what do you do"))
        {
            return $"My purpose is to help you, {userName}, learn about common cybersecurity threats and how to protect yourself online.";
        }

        if (message.Contains("what can i ask") || message.Contains("what can i ask you about"))
        {
            return "You can ask me about password safety, phishing, suspicious links, safe browsing, and other basic cybersecurity topics.";
        }

        if (message.Contains("password"))
        {
            return "Use a long, unique password for each important account. Avoid using your name, birthday, or other easy-to-guess information. A password manager can also help you create and store strong passwords.";
        }

        if (message.Contains("phishing"))
        {
            return "Phishing is when someone tries to trick you into giving away information, often through fake emails, messages or websites. Check the sender and link carefully before responding.";
        }

        if (message.Contains("link") || message.Contains("suspicious"))
        {
            return "Be careful with unexpected links. Check where the link leads before clicking, and avoid entering personal information on websites you do not trust.";
        }

        if (message.Contains("safe browsing") || message.Contains("browsing"))
        {
            return "For safer browsing, use trusted websites, keep your browser updated, avoid suspicious downloads, and check that websites use secure connections.";
        }

        return "I didn't quite understand that. You can ask me about passwords, phishing, suspicious links, or safe browsing.";
    }
}