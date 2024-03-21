using ClientTest;

namespace NetAppForm
{
    public partial class Form1 : Form
    {
        private Client _client;
        public Form1()
        {
            InitializeComponent();
            _client = new Client();
            ConnectToServer();
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

        private void UpdateTextBox(bool flag)
        {
            if (textBoxMessage.InvokeRequired)
            {
                textBoxMessage.Invoke(new Action<bool>(UpdateTextBox), flag);
            }
            else
            {
              textBoxMessage.Enabled = flag;
            }

        }

        private void UpdateButton(bool flag)
        {
            if (btnSend.InvokeRequired)
            {
                btnSend.Invoke(new Action<bool>(UpdateButton), flag);
            }
            else
            {
                btnSend.Enabled = flag;
            }

        }
        private async Task ConnectToServer()
        {
            if (!_client.CheckConnected)
            {
                if (!_client.IsConnected())
                {
                    btnSend.Enabled = false;
                    textBoxMessage.Enabled = false;
                    richTextBoxChat.Text = "NO CONNECTION!";
                    return;
                }
            }
       
            while (_client.CheckConnected)
            {
                var str = await _client.GetMsgAsync();
                UpdateChatTextBox(str);

                UpdateButton(true);

                UpdateTextBox(true);

                await Task.Delay(3000);
            }
            MessageBox.Show("NO CONNECTION!");
        }
    }
}