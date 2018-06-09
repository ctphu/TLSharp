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
namespace TLSharp.Example
{
    public partial class Form1 : Form
    {
        TelegramApi teleApi = new TelegramApi();
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnSendMessage_Click(object sender, EventArgs e)
        {
            await teleApi.SendMessage(txtReceiveNumber.Text,txtMessage.Text);
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
            await teleApi.MakeAuthAsync(txtCode.Text);
            
            //var user = await client.MakeAuthAsync(NumberToAuthenticate, hash, code);
        }
    }
}
