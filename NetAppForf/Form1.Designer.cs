namespace NetAppForm
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            textBoxMessage = new TextBox();
            btnSend = new Button();
            richTextBoxChat = new RichTextBox();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(12, 386);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(554, 23);
            textBoxMessage.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(572, 386);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(119, 26);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // richTextBoxChat
            // 
            richTextBoxChat.BackColor = SystemColors.ActiveCaption;
            richTextBoxChat.Location = new Point(12, 10);
            richTextBoxChat.Name = "richTextBoxChat";
            richTextBoxChat.ReadOnly = true;
            richTextBoxChat.Size = new Size(679, 372);
            richTextBoxChat.TabIndex = 2;
            richTextBoxChat.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 425);
            Controls.Add(richTextBoxChat);
            Controls.Add(btnSend);
            Controls.Add(textBoxMessage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxMessage;
        private Button btnSend;
        private RichTextBox richTextBoxChat;
        private System.Windows.Forms.Timer timer1;
    }
}