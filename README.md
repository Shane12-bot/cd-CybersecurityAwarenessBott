# Cybersecurity Awareness Bot

## Overview
The Cybersecurity Awareness Bot is a C# application designed to help users learn about online safety and common cybersecurity threats. The project includes a Windows Forms graphical user interface (GUI).

## Features
- Welcome message with ASCII art.
- Audio greeting using a WAV file.
- Randomised cybersecurity tips.
- Password safety, phishing, scams, privacy and safe browsing topics.
- Follow-up responses, including "Tell me more" and "Give me another tip".
- Conversation memory for the user's name and favourite topic.
- Sentiment detection for worried, curious and frustrated messages.
- Input validation and error handling.
- Clear/reset conversation button.
- GitHub Actions workflow for automated builds.

## Technologies
- C#
- .NET 10
- Windows Forms
- Visual Studio
- GitHub Actions

## Getting Started

### Requirements
- Windows
- .NET 10 SDK
- Visual Studio with the .NET desktop development workload

### Run the application
1. Clone or download this repository.
2. Open the solution in Visual Studio.
3. Set `CybersecurityAwarenessBot.GUI` as the startup project.
4. Build the solution.
5. Run the application using **Ctrl + F5**.

## Example Messages
- `Tell me about passwords`
- `How can I recognise phishing?`
- `I'm interested in privacy`
- `My name is Alex`
- `What is my name?`
- `Give me another tip`
- `I'm worried about scams`

## Automated Build
The repository includes a GitHub Actions workflow at `.github/workflows/ci.yml` to build the solution automatically when changes are pushed or pull requests are opened.

## Audio
The application uses `Audio/welcome.wav` for its welcome greeting. Ensure the WAV file is included in the repository and copied to the GUI application's output directory.

## Presentation
**Video presentation:** https://youtu.be/I7N1AXfFDPQ

## Author
shane ratshibvumo st10442635
