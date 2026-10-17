
using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot.GUI.Services
{
    public class ChatbotService
    {
        private readonly Dictionary<string, List<string>> responses =
            new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                ["password"] = new List<string>
                {
                    "Use a long, unique password for every account. A password manager can help you keep track of them.",
                    "Turn on multi-factor authentication wherever possible, especially for email and banking accounts.",
                    "Avoid using personal details in passwords, such as your birthday or name."
                },

                ["phishing"] = new List<string>
                {
                    "Check the sender's address carefully. Scammers may imitate trusted organisations.",
                    "Be cautious of messages that pressure you to act urgently or provide personal information.",
                    "Don't open unexpected attachments or follow suspicious links. Verify the message through an official channel."
                },

                ["scam"] = new List<string>
                {
                    "Be suspicious of offers that promise guaranteed rewards or demand urgent payments.",
                    "Never share your banking PIN, password or one-time password with someone who contacts you unexpectedly.",
                    "Verify unexpected requests for money by contacting the person or organisation using a trusted number."
                },

                ["privacy"] = new List<string>
                {
                    "Review the privacy settings on your social media accounts and limit who can see your information.",
                    "Share personal information online only when necessary, and check that a website is legitimate.",
                    "Use multi-factor authentication and keep your devices and applications updated."
                },

                ["safe browsing"] = new List<string>
                {
                    "Make sure websites use HTTPS before entering sensitive information.",
                    "Avoid downloading files from websites or sources you do not trust.",
                    "Keep your browser updated and be careful when clicking unfamiliar links."
                }
            };

        private string userName = string.Empty;
        private string favouriteTopic = string.Empty;
        private string currentTopic = string.Empty;

        private readonly Random random = new Random();

        public string GetResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return "Please enter a message so I can help you.";

            string input = message.Trim();
            string normalised = input.TrimEnd('.', '!', '?', ' ');

            // Remember the user's name.
            if (input.StartsWith("my name is ", StringComparison.OrdinalIgnoreCase))
            {
                string name = input.Substring("my name is ".Length)
                    .Trim()
                    .TrimEnd('.', '!', '?');

                if (!string.IsNullOrWhiteSpace(name))
                {
                    userName = name;
                    return $"Nice to meet you, {userName}! I'll remember your name during this conversation.";
                }
            }

            // Remember the user's favourite topic.
            string extractedTopic = ExtractFavouriteTopic(input);

            if (!string.IsNullOrWhiteSpace(extractedTopic))
            {
                favouriteTopic = extractedTopic;
                string recognisedTopic = FindTopic(favouriteTopic);

                if (!string.IsNullOrWhiteSpace(recognisedTopic))
                    currentTopic = recognisedTopic;

                return $"Great! I'll remember that you're interested in {favouriteTopic}.";
            }

            // Recall the user's name.
            if (ContainsAny(normalised,
                "what is my name",
                "what's my name",
                "whats my name",
                "who am i",
                "do you remember my name"))
            {
                return string.IsNullOrWhiteSpace(userName)
                    ? "You haven't told me your name yet. Try saying 'My name is Shane'."
                    : $"Your name is {userName}.";
            }

            // Recall the user's favourite topic.
            if (ContainsAny(normalised,
                "what am i interested in",
                "what is my favourite topic",
                "what is my favorite topic",
                "what's my favourite topic",
                "what's my favorite topic"))
            {
                return string.IsNullOrWhiteSpace(favouriteTopic)
                    ? "You haven't told me your favourite topic yet. Try saying 'I'm interested in privacy'."
                    : $"You're interested in {favouriteTopic}.";
            }

            // Sentiment detection: empathy and a practical tip.
            if (ContainsAny(input,
                "worried", "worry", "scared", "afraid", "concerned", "anxious"))
                return GetSentimentResponse("worried");

            if (ContainsAny(input,
                "curious", "interested", "want to learn", "wondering", "keen to learn"))
                return GetSentimentResponse("curious");

            if (ContainsAny(input,
                "frustrated", "frustrating", "confused", "annoyed", "overwhelmed"))
                return GetSentimentResponse("frustrated");

            // Follow-up questions.
            if (ContainsAny(input,
                "give me another tip", "another tip", "tell me more",
                "explain more", "more information", "another one",
                "more tips", "go on"))
            {
                string topic = currentTopic;

                if (string.IsNullOrWhiteSpace(topic))
                    topic = FindTopic(favouriteTopic);

                if (IsKnownTopic(topic))
                {
                    currentTopic = topic;
                    return GetPersonalisedResponse(topic);
                }

                return "I'd be happy to give you another tip. Ask about passwords, phishing, scams, privacy or safe browsing first.";
            }

            // General conversation.
            if (ContainsAny(input, "how are you"))
                return "I'm running well and ready to help you stay safe online!";

            if (ContainsAny(input, "your purpose", "what is your purpose"))
                return "I'm here to help you recognise cyber threats and practise safer online habits.";

            if (ContainsAny(input, "what can i ask", "what can you help me with"))
                return "Ask me about password safety, phishing, scams, privacy or safe browsing. You can also ask for another tip.";

            // Greetings.
            if (normalised.Equals("hello", StringComparison.OrdinalIgnoreCase) ||
                normalised.Equals("hi", StringComparison.OrdinalIgnoreCase) ||
                normalised.Equals("hey", StringComparison.OrdinalIgnoreCase))
            {
                return string.IsNullOrWhiteSpace(userName)
                    ? "Hello! How can I help you stay safe online today?"
                    : $"Hello, {userName}! How can I help you stay safe online today?";
            }

            // Goodbye.
            if (ContainsAny(normalised, "bye", "goodbye", "see you", "good night"))
            {
                return string.IsNullOrWhiteSpace(userName)
                    ? "Goodbye! Stay safe online and remember to think before you click."
                    : $"Goodbye, {userName}! Stay safe online and remember to think before you click.";
            }

            // Cybersecurity topics.
            string matchedTopic = FindTopic(input);

            if (IsKnownTopic(matchedTopic))
            {
                currentTopic = matchedTopic;
                return GetPersonalisedResponse(currentTopic);
            }

            return "I'm not sure I understand. Try asking about passwords, phishing, scams, privacy or safe browsing. You can also tell me if you're worried, curious or frustrated.";
        }

        private string ExtractFavouriteTopic(string input)
        {
            string[] prefixes =
            {
                "i'm interested in ",
                "i am interested in ",
                "my favourite topic is ",
                "my favorite topic is ",
                "i like learning about ",
                "i am curious about ",
                "i'm curious about "
            };

            foreach (string prefix in prefixes)
            {
                if (input.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    return input.Substring(prefix.Length)
                        .Trim()
                        .TrimEnd('.', '!', '?');
                }
            }

            return string.Empty;
        }

        private string GetRandomResponse(string topic)
        {
            if (!responses.TryGetValue(topic, out List<string>? options) ||
                options == null ||
                options.Count == 0)
            {
                return "I don't have information about that topic yet.";
            }

            return options[random.Next(options.Count)];
        }

        private string GetPersonalisedResponse(string topic)
        {
            string response = GetRandomResponse(topic);

            return string.IsNullOrWhiteSpace(userName)
                ? response
                : $"{userName}, {response}";
        }

        private bool ContainsAny(string input, params string[] phrases)
        {
            foreach (string phrase in phrases)
            {
                if (input.IndexOf(phrase, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }

            return false;
        }

        private string GetSentimentResponse(string sentiment)
        {
            string topic = currentTopic;

            if (!IsKnownTopic(topic))
                topic = FindTopic(favouriteTopic);

            string tip;

            if (IsKnownTopic(topic))
            {
                tip = GetRandomResponse(topic);
            }
            else
            {
                tip = sentiment switch
                {
                    "worried" => "Never share your passwords, PINs or one-time passwords with someone who contacts you unexpectedly.",
                    "curious" => "Start by using unique passwords and enabling multi-factor authentication on important accounts.",
                    "frustrated" => "Start with one simple step: use a unique password for your email account and enable multi-factor authentication.",
                    _ => "Use unique passwords and enable multi-factor authentication on important accounts."
                };
            }

            return sentiment switch
            {
                "worried" =>
                    "It's understandable to feel worried about cybersecurity. You're doing the right thing by learning about it. Here's a practical tip: " + tip,

                "curious" =>
                    "It's great that you're curious about cybersecurity! Here's something useful to try: " + tip,

                "frustrated" =>
                    "Cybersecurity can feel confusing, but we can take it one step at a time. Here's a practical tip: " + tip,

                _ => "I'm here to help. Let's work through the cybersecurity topic together."
            };
        }

        private bool IsKnownTopic(string topic)
        {
            return !string.IsNullOrWhiteSpace(topic) &&
                   responses.ContainsKey(topic);
        }

        private string FindTopic(string topic)
        {
            if (string.IsNullOrWhiteSpace(topic))
                return string.Empty;

            if (topic.Contains("password", StringComparison.OrdinalIgnoreCase))
                return "password";

            if (topic.Contains("phishing", StringComparison.OrdinalIgnoreCase))
                return "phishing";

            if (topic.Contains("scam", StringComparison.OrdinalIgnoreCase))
                return "scam";

            if (topic.Contains("privacy", StringComparison.OrdinalIgnoreCase))
                return "privacy";

            if (topic.Contains("browsing", StringComparison.OrdinalIgnoreCase) ||
                topic.Contains("browser", StringComparison.OrdinalIgnoreCase))
                return "safe browsing";

            return string.Empty;
        }
    }
}
