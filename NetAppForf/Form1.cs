using ClientTest;
using System;
using System.Diagnostics;

namespace NetAppForm
{
    public partial class Form1 : Form
    {
        private Client _client;
        private bool _start;

        public Form1()
        {
            InitializeComponent();
            _client = new Client();

            Task.Run(() => { CheckConnection(); });
            Task.Run(() => { ConnectToServer(); });
            
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            _client.ReadMsg(textBoxMessage.Text);
        }

        private void UpdateChatTextBox(string msg)
        {
            if (richTextBoxChat.InvokeRequired)
            {
                richTextBoxChat.Invoke(new Action<string>(UpdateChatTextBox), msg);
            }
            else
            {
                richTextBoxChat.AppendText(msg + "\n");
            }

        }
        private void UpdatTextBox(bool flag)
        {
            if (textBoxMessage.InvokeRequired)
            {
                textBoxMessage.Invoke(new Action<bool>(UpdatTextBox), flag);
            }
            else
            {
                textBoxMessage.Enabled = flag;
            }

        }
        private void UpdatBtn(bool flag)
        {
            if (btnSend.InvokeRequired)
            {
                btnSend.Invoke(new Action<bool>(UpdatBtn), flag);
            }
            else
            {
                btnSend.Enabled = flag;
            }

        }


        private async Task CheckConnection() 
        {
            while (true)
            {
               
                if (_client.CheckConnected)
                {
                    UpdatBtn(true);
                    UpdatTextBox(true);
                    _start = true;
                }
                else
                {
                    UpdatBtn(false);
                    UpdatTextBox(false);
                    _start = false;
                    _client.IsConnected();
                }
                await Task.Delay(1000);

            }
          
        }
        private async Task ConnectToServer()
        {
            while (true)
            {
                if (_start)
                {
                    var str = await _client.GetMsgAsync();

                    UpdateChatTextBox(str);
                }
            }
            MessageBox.Show("NO CONNECTION!");
        }
    }
}