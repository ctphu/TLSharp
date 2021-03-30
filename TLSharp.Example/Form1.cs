using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using TeleSharp.TL;
using TeleSharp.TL.Updates;

namespace TLSharp.Example
{
    public partial class Form1 : Form
    {
        TelegramApi teleApi = new TelegramApi();
        bool IsReceiveMessage;
        public Form1()
        {
            InitializeComponent();
        }
        delegate void SetTextCallback(string text);
        private void AddText(string text)
        {
            text = text + "\r\n" + tbReceipt.Text;
            if (this.tbReceipt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(AddText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbReceipt.Text = text;
            }
        }
        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtReceiveNumber.Text))
                    await teleApi.SendMessage(txtReceiveNumber.Text, txtMessage.Text);
                else if (!string.IsNullOrEmpty(tbUserName.Text))
                    await teleApi.SendMessageToUser(tbUserName.Text, txtMessage.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void btnGetCode_Click(object sender, EventArgs e)
        {
            teleApi.PhoneNumber = txtNumber.Text;
            await teleApi.AuthUser();
            MessageBox.Show("Telegram Code da duoc gui ve dien thoai. xin kiem tra tin nhan.");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Kiem tra trang thai login
            //Neu muon chuyen user khac thi vo thu muc bin xoa file session.dat
            //file session.dat se duoc tao lai khi login thanh cong
            
            var authorized = await teleApi.IsUserAuthorized();
            //teleApi.PhoneNumber = txtNumber.Text;
            if (authorized)
            {
                grLogin.Enabled = false;
                grMessage.Enabled = true;
                
            }
            else
            {
                grLogin.Enabled = true;
                grMessage.Enabled = false;

            }
        }
        

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Nhap vao Telegram Code truoc khi login. Neu chua co Code thi nhan nut GETCODE");
                return;
            }
            teleApi.PhoneNumber = txtNumber.Text;
            await teleApi.MakeAuthAsync(txtCode.Text);
            
            //var user = await client.MakeAuthAsync(NumberToAuthenticate, hash, code);
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            var client = new TLSharp.Core.TelegramClient(teleApi.apiId, teleApi.apiHash);
            await client.ConnectAsync();
            while (true)
            {
                var state = await client.SendRequestAsync<TLState>(new TLRequestGetState());
                var req = new TLRequestGetDifference() { Date = state.Date, Pts = state.Pts, Qts = state.Qts };
                var diff = await client.SendRequestAsync<TLAbsDifference>(req) as TLDifference;
                if (diff != null)
                {
                    foreach (var upd in diff.OtherUpdates.ToList().OfType<TLUpdateNewChannelMessage>())
                    {
                        tbReceipt.Text = (upd.Message as TLMessage).Message + tbReceipt.Text;
                        //Console.WriteLine((upd.Message as TLMessage).Message);
                    }
                    foreach (var ch in diff.Chats.ToList().OfType<TLChannel>().Where(x => !x.Left))
                    {
                        var ich = new TLInputChannel() { ChannelId = ch.Id, AccessHash = (long)ch.AccessHash };
                        var readed = new TeleSharp.TL.Channels.TLRequestReadHistory() { Channel = ich, MaxId = -1 };
                        await client.SendRequestAsync<bool>(readed);
                    }
                }
                await Task.Delay(500);
            }

        }
    }
}
