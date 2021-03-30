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
                //while (true)
                //{
                //    var state = await telegram.SendRequestAsync<TLState>(new TLRequestGetState());
                //    var req = new TLRequestGetDifference() { date = state.date, pts = state.pts, qts = state.qts };
                //    var diff = await telegram.SendRequestAsync<TLAbsDifference>(req) as TLDifference;
                //    if (diff != null)
                //    {
                //        foreach (var upd in diff.other_updates.lists.OfType<TLUpdateNewChannelMessage>())
                //            Console.WriteLine((upd.message as TLMessage).message);

                //        foreach (var ch in diff.chats.lists.OfType<TLChannel>().Where(x => !x.left))
                //        {
                //            var ich = new TLInputChannel() { channel_id = ch.id, access_hash = (long)ch.access_hash };
                //            var readed = new TeleSharp.TL.Channels.TLRequestReadHistory() { channel = ich, max_id = -1 };
                //            await telegram.SendRequestAsync<bool>(readed);
                //        }
                //    }
                //    await Task.Delay(500);
                //}
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

        private DateTime GetSQLDate()
        {
            string sqlserver = "localhost1,2020";
            SqlConnection conn;
            DataSet ds = null;
            DateTime ret = DateTime.Now.AddDays(-1);
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Server=" + sqlserver + ";Database=Mobile_LOTO;User ID=mobile_loto_client;Password=mobileloto13579135;Max Pool Size=250; Connection Timeout=300";
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select GETDATE() AS CurrentDate", conn);
                da.SelectCommand.CommandTimeout = 1000;
                ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ret = DateTime.Parse(ds.Tables[0].Rows[0]["CurrentDate"].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                ret = DateTime.Now.AddDays(-1);
            }
            return ret;
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
            ////var client = new TLSharp.Core.TelegramClient(teleApi.apiId, teleApi.apiHash);
            //TLMessage mSend, mReceive;
            //List<string> botList = new List<string>();
            //botList.Add("bbitex_bot");
            ////botList.Add("nt6802bot");
            ////botList.Add("nt6803bot");
            ////botList.Add("nt6806bot");
            ////botList.Add("nt6807bot");
            ////botList.Add("nt6808bot");
            ////botList.Add("nt6809bot");
            //if (btStart.Text == "Start")
            //{
            //    IsReceiveMessage = true;
            //    btStart.Text = "Stop";
            //    while (IsReceiveMessage)
            //    {
            //        try
            //        {
            //            var messages = await teleApi.GatherChannelHistory("PMSA Signals Premium", 0, -1);
            //            //if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour <= 18)
            //            //{
            //            //    foreach (string sCurrentBot in botList)
            //            //    {
            //            //        mSend = await teleApi.GetLastMessageFromUser(sCurrentBot);
            //            //        AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + sCurrentBot + "|" + mSend.Id + "|" + mSend.FromId + "|" + mSend.Message);
            //            //        await teleApi.SendMessageToUser(sCurrentBot, "/me");
            //            //        await Task.Delay(10000);
            //            //        mReceive = await teleApi.GetLastMessageFromUser(sCurrentBot);
            //            //        if ((mSend.Id != mReceive.Id) && (mReceive.Message != "/me"))
            //            //        {
            //            //            AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + sCurrentBot + "|" + mReceive.Id + "|" + mReceive.FromId + "|" + mReceive.Message);
            //            //        }
            //            //        else
            //            //        {
            //            //            AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + sCurrentBot + " failed");
            //            //            await teleApi.SendMessageToUser("tommykao", sCurrentBot + " failed");
            //            //            await Task.Delay(1000);
            //            //            await teleApi.SendMessageToUser("tommykaomy", sCurrentBot + " failed");
            //            //            await Task.Delay(1000);
            //            //            await teleApi.SendMessage("+84906841595", sCurrentBot + " failed");
            //            //            //await teleApi.SendMessageToUser("tommykao", sCurrentBot + " failed");
            //            //        }
            //            //        await Task.Delay(1000);
            //            //    }
            //            //}
            //            //AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + " check connect to sqlserver.");
            //            //if (GetSQLDate().ToString("yyyyMMdd") != DateTime.Now.ToString("yyyyMMdd"))
            //            //{
            //            //    AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + " connect to sqlserver failed.");
            //            //    await teleApi.SendMessageToUser("tommykao", " connect to sqlserver failed.");
            //            //    await Task.Delay(1000);
            //            //    await teleApi.SendMessageToUser("tommykaomy", " connect to sqlserver failed.");
            //            //    await Task.Delay(1000);
            //            //    await teleApi.SendMessage("+84906841595", " connect to sqlserver failed.");
            //            //    await Task.Delay(1000);
            //            //}
            //            //else
            //            //{
            //            //    AddText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss|") + " check connect to sqlserver OK.");
            //            //}
            //        }
            //        catch (Exception ex)
            //        {
            //            AddText(ex.ToString());
            //        }


            //        //var client = new TLSharp.Core.TelegramClient(teleApi.apiId, teleApi.apiHash);

            //        //await client.ConnectAsync();
            //        //if (client.IsUserAuthorized())
            //        //{
            //        //    var state = await client.SendRequestAsync<TLState>(new TLRequestGetState());
            //        //    var req = new TLRequestGetDifference() { Date = state.Date, Pts = state.Pts, Qts = state.Qts };
            //        //    var diff = await client.SendRequestAsync<TLAbsDifference>(req) as TLDifference;
            //        //    if (diff != null)
            //        //    {
            //        //        foreach (var upd in diff.OtherUpdates.OfType<TLUpdateNewChannelMessage>())
            //        //            Console.WriteLine((upd.Message as TLMessage).Message);

            //        //        foreach (var ch in diff.Chats.OfType<TLChannel>().Where(x => !x.Left))
            //        //        {
            //        //            var ich = new TLInputChannel() { ChannelId = ch.Id, AccessHash = (long)ch.AccessHash };
            //        //            var readed = new TeleSharp.TL.Channels.TLRequestReadHistory() { Channel = ich, MaxId = -1 };
            //        //            await client.SendRequestAsync<bool>(readed);
            //        //        }
            //        //    }

            //        //}

            //        await Task.Delay(600000);
            //    }
            //}
            //else
            //{
            //    btStart.Text = "Start";
            //    IsReceiveMessage = false;
            //}
            ////var client = new TLSharp.Core.TelegramClient(teleApi.apiId, teleApi.apiHash);
            ////await client.ConnectAsync();
            ////if(client.IsUserAuthorized())
            ////{
            ////    if(btStart.Text == "Start")
            ////    {
            ////        IsReceiveMessage = true;
            ////        btStart.Text = "Stop";
            ////        while (IsReceiveMessage)
            ////        {
            ////            //var state = await client.SendRequestAsync<TLState>(new TLRequestGetState());
            ////            //var req = new TLRequestGetDifference() { Date = state.Date, Pts = state.Pts, Qts = state.Qts };
            ////            //var diff = await client.SendRequestAsync<TLAbsDifference>(req) as TLDifference;
            ////            //if (diff != null)
            ////            //{
            ////            //    foreach (TLMessage newmessage in diff.NewMessages)
            ////            //        AddText(newmessage.FromId + ":" + newmessage.Message);

            ////            //    //foreach (var ch in diff.Chats.OfType<TLChannel>().Where(x => !x.Left))
            ////            //    //{
            ////            //    //    var ich = new TLInputChannel() { ChannelId = ch.Id, AccessHash = (long)ch.AccessHash };
            ////            //    //    var readed = new TeleSharp.TL.Channels.TLRequestReadHistory() { Channel = ich, MaxId = -1 };
            ////            //    //    await client.SendRequestAsync<bool>(readed);
            ////            //    //}
            ////            //}
            ////            //await Task.Delay(500);
            ////            var state = await client.SendRequestAsync<TLState>(new TLRequestGetState());
            ////            var req = new TLRequestGetDifference() { Date = state.Date, Pts = state.Pts, Qts = state.Qts };
            ////            var diff = await client.SendRequestAsync<TLAbsDifference>(req) as TLDifference;
            ////            if (diff != null)
            ////            {
            ////                foreach (var upd in diff.OtherUpdates.OfType<TLUpdateNewChannelMessage>())
            ////                    Console.WriteLine((upd.Message as TLMessage).Message);

            ////                foreach (var ch in diff.Chats.OfType<TLChannel>().Where(x => !x.Left))
            ////                {
            ////                    var ich = new TLInputChannel() { ChannelId = ch.Id, AccessHash = (long)ch.AccessHash };
            ////                    var readed = new TeleSharp.TL.Channels.TLRequestReadHistory() { Channel = ich, MaxId = -1 };
            ////                    await client.SendRequestAsync<bool>(readed);
            ////                }
            ////            }
            ////            await Task.Delay(5000);
            ////        }
            ////    }
            ////    else
            ////    {
            ////        btStart.Text = "Start";
            ////        IsReceiveMessage = false;
            ////    }
            ////}
        }
    }
}
