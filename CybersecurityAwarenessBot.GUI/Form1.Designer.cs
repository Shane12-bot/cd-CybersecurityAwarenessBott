namespace CybersecurityAwarenessBot.GUI
{
    partial class frmCybersecurityBot
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            saveFileDialog1 = new SaveFileDialog();
            lablTitle = new Label();
            rtbChatHistory = new RichTextBox();
            txtUserInput = new TextBox();
            btnSend = new Button();
            lblWelcome = new Label();
            lblLogo = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lablTitle
            // 
            lablTitle.AutoSize = true;
            lablTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lablTitle.Location = new Point(180, 20);
            lablTitle.Name = "lablTitle";
            lablTitle.Size = new Size(457, 29);
            lablTitle.TabIndex = 0;
            lablTitle.Text = "CYBERSECURITY AWARENESS BOT";
            // 
            // rtbChatHistory
            // 
            rtbChatHistory.BackColor = Color.White;
            rtbChatHistory.BorderStyle = BorderStyle.FixedSingle;
            rtbChatHistory.Font = new Font("Microsoft Sans Serif", 10F);
            rtbChatHistory.ForeColor = Color.Black;
            rtbChatHistory.Location = new Point(136, 114);
            rtbChatHistory.Name = "rtbChatHistory";
            rtbChatHistory.ReadOnly = true;
            rtbChatHistory.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChatHistory.Size = new Size(561, 126);
            rtbChatHistory.TabIndex = 1;
            rtbChatHistory.Text = "";
            // 
            // txtUserInput
            // 
            txtUserInput.BackColor = Color.White;
            txtUserInput.Font = new Font("Microsoft Sans Serif", 10F);
            txtUserInput.ForeColor = Color.FromArgb(0, 255, 120);
            txtUserInput.Location = new Point(136, 260);
            txtUserInput.Name = "txtUserInput";
            txtUserInput.Size = new Size(180, 23);
            txtUserInput.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.DarkGreen;
            btnSend.Font = new Font("Microsoft Sans Serif", 10F);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(806, 245);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 3;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(255, 70);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(266, 19);
            lblWelcome.TabIndex = 4;
            lblWelcome.Text = "Welcome to Cybersecurity Awareness Bot!";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Consolas", 9F);
            lblLogo.ForeColor = Color.Lime;
            lblLogo.Location = new Point(248, 291);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(273, 56);
            lblLogo.TabIndex = 5;
            lblLogo.Text = "+----------------------------------+\n\t\\|     CYBERSECURITY AWARENESS      \\|\n\t\\|              BOT                 \\|\n\t+----------------------------------+";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Location = new Point(712, 245);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Clear Chat";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmCybersecurityBot
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(915, 561);
            Controls.Add(button1);
            Controls.Add(lblLogo);
            Controls.Add(lblWelcome);
            Controls.Add(btnSend);
            Controls.Add(txtUserInput);
            Controls.Add(rtbChatHistory);
            Controls.Add(lablTitle);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            Name = "frmCybersecurityBot";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cybersecurity Awareness Assistant";
            Load += frmCybersecurityBot_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Label lablTitle;
        private RichTextBox rtbChatHistory;
        private TextBox txtUserInput;
        private Button btnSend;
        private Label lblWelcome;
        private Label lblLogo;
        private Button button1;
    }
}
