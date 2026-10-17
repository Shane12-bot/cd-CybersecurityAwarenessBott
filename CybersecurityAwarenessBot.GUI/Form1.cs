
using System;
using System.Windows.Forms;
using CybersecurityAwarenessBot.GUI.Services;

namespace CybersecurityAwarenessBot.GUI
{
    public partial class frmCybersecurityBot : Form
    {
        private readonly ChatbotService chatbotService =
            new ChatbotService();

        private readonly AudioService audioService =
            new AudioService();

        public frmCybersecurityBot()
        {
            InitializeComponent();

            Load += frmCybersecurityBot_Load;
            btnSend.Click += btnSend_Click;
            button1.Click += button1_Click;
            txtUserInput.KeyDown += txtUserInput_KeyDown;
        }

        private void frmCybersecurityBot_Load(object? sender, EventArgs e)
        {
            ShowWelcomeMessage();
            audioService.PlayWelcomeGreeting();
            txtUserInput.Focus();
        }

        private void ShowWelcomeMessage()
        {
            rtbChatHistory.Clear();

            rtbChatHistory.AppendText(
                "==================================================" +
                Environment.NewLine);
            rtbChatHistory.AppendText(
                "        CYBERSECURITY AWARENESS BOT" +
                Environment.NewLine);
            rtbChatHistory.AppendText(
                "==================================================" +
                Environment.NewLine);

            rtbChatHistory.AppendText("              /\\" + Environment.NewLine);
            rtbChatHistory.AppendText("             /  \\" + Environment.NewLine);
            rtbChatHistory.AppendText("            /____\\" + Environment.NewLine);
            rtbChatHistory.AppendText("            |    |" + Environment.NewLine);
            rtbChatHistory.AppendText("            |____|" + Environment.NewLine + Environment.NewLine);

            rtbChatHistory.AppendText(
                "Bot: Welcome to the Cybersecurity Awareness Bot!" +
                Environment.NewLine);
            rtbChatHistory.AppendText(
                "Bot: I can help you learn about:" + Environment.NewLine);
            rtbChatHistory.AppendText("     • Password safety" + Environment.NewLine);
            rtbChatHistory.AppendText("     • Phishing" + Environment.NewLine);
            rtbChatHistory.AppendText("     • Online scams" + Environment.NewLine);
            rtbChatHistory.AppendText("     • Privacy" + Environment.NewLine);
            rtbChatHistory.AppendText("     • Safe browsing" + Environment.NewLine + Environment.NewLine);

            rtbChatHistory.AppendText(
                "Bot: You can tell me your name or favourite topic." +
                Environment.NewLine);
            rtbChatHistory.AppendText(
                "Bot: Try 'My name is Alex' or 'I'm interested in privacy'." +
                Environment.NewLine);
            rtbChatHistory.AppendText(
                "Bot: Ask 'Tell me more' or 'Give me another tip'." +
                Environment.NewLine + Environment.NewLine);

            rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
            rtbChatHistory.ScrollToCaret();
        }

        private void btnSend_Click(object? sender, EventArgs e)
        {
            string userMessage = txtUserInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show(
                    "Please type a message before clicking Send.",
                    "Empty Message",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtUserInput.Focus();
                return;
            }

            try
            {
                string botResponse = chatbotService.GetResponse(userMessage);

                rtbChatHistory.AppendText(
                    "You: " + userMessage + Environment.NewLine);
                rtbChatHistory.AppendText(
                    "Bot: " + botResponse + Environment.NewLine + Environment.NewLine);

                rtbChatHistory.SelectionStart = rtbChatHistory.TextLength;
                rtbChatHistory.ScrollToCaret();

                txtUserInput.Clear();
                txtUserInput.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Sorry, something went wrong while processing your message. Please try again.",
                    "Chatbot Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            ShowWelcomeMessage();
            txtUserInput.Clear();
            txtUserInput.Focus();
        }

        private void txtUserInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSend.PerformClick();
            }
        }
    }
}