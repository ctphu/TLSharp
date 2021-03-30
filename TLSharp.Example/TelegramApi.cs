using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
using TeleSharp.TL.Channels;
using TeleSharp.TL.Messages;

namespace TLSharp.Example
{
    public class TelegramApi
    {
        public int apiId = 193474;
        public string apiHash = "7a74bfa34444ba1c869159957bb21a08";
        public string phoneCodeHash = "";
        public string PhoneNumber { get; set; }
        public virtual async Task AuthUser()
        {
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);

            await client.ConnectAsync();

            phoneCodeHash = await client.SendCodeRequestAsync(PhoneNumber);

        }
        public virtual async Task<bool> IsUserAuthorized()
        {
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);

            await client.ConnectAsync();

            return client.IsUserAuthorized();

        }
        public async Task<List<TLMessage>> GatherChannelHistory(string channelName, int offset = 0, int maxId = -1, int limit = 50)
        {
            List<TLMessage> _resultMessages = new List<TLMessage>();
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
            await client.ConnectAsync();

            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            var chat = dialogs.Chats.ToList()
                .OfType<TLChannel>()
                .FirstOrDefault(c => c.Title == channelName);

            if (chat.AccessHash != null)
            {
                TLChannel channel = new TLChannel() { Id = chat.Id, AccessHash = chat.AccessHash };

                var request = new TLRequestGetFullChannel();
                
                var fullChat = await client.SendRequestAsync<TLRequestGetFullChannel>(request);
                //var request = new TLRequestGetFullChat() { ChatId = chat.Id };
                //var fullChat = await client.SendRequestAsync<TeleSharp.TL.Messages.TLChatFull>(request);
                //var request = new TLRequestGetMessages() { Id = chat. };
                //var fullChat = await client.SendRequestAsync<TeleSharp.TL.Channels.TLRequestGetMessages>(request);
                //var request = new TLRequestGetAllChats() { };
                //var fullChat = await client.SendRequestAsync<TeleSharp.TL.Messages.TLRequestGetAllChats>(request);

                var tlAbsMessages =
                    await client.GetHistoryAsync(
                        new TLInputPeerChannel { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, offset,
                        maxId, limit);

                var tlChannelMessages = (TLChannelMessages)tlAbsMessages;

                for (var index = 0; index < tlChannelMessages.Messages.Count - 1; index++)
                {
                    var tlAbsMessage = tlChannelMessages.Messages.ToList()[index];
                    var message = (TLMessage)tlAbsMessage;
                    //Now you have the message and you can do what you need with it
                    //the code below is an example of messages classification
                    if (message.Media == null)
                    {
                        _resultMessages.Add(new TLMessage()
                        {
                            Id = message.Id,
                            FromId = chat.Id,
                            Message = message.Message,
                            Views = message.Views,
                        });
                    }
                    else
                    {

                        switch (message.Media.GetType().ToString())
                        {
                            case "TeleSharp.TL.TLMessageMediaPhoto":
                                var tLMessageMediaPhoto = (TLMessageMediaPhoto)message.Media;

                                _resultMessages.Add(new TLMessage()
                                {
                                    Id = message.Id,
                                    FromId = chat.Id,
                                    Message = message.Message,
                                    Views = message.Views,
                                    Media = message.Media,

                                });
                                break;
                                //case "TeleSharp.TL.TLMessageMediaDocument":
                                //    var tLMessageMediaDocument = (TLMessageMediaDocument)message.media;

                                //    _resultMessages.Add(new ChannelMessage()
                                //    {
                                //        Id = message.id,
                                //        ChannelId = chat.id,
                                //        Content = tLMessageMediaDocument.caption,
                                //        Type = EnChannelMessage.MediaDocument,
                                //        Views = message.views ?? 0,
                                //    });
                                //    break;
                                //case "TeleSharp.TL.TLMessageMediaWebPage":
                                //    var tLMessageMediaWebPage = (TLMessageMediaWebPage)message.media;
                                //    string url = string.Empty;
                                //    if (tLMessageMediaWebPage.webpage.GetType().ToString() != "TeleSharp.TL.TLWebPageEmpty")
                                //    {
                                //        var webPage = (TLWebPage)tLMessageMediaWebPage.webpage;
                                //        url = webPage.url;
                                //    }

                                //    _resultMessages.Add(new ChannelMessage
                                //    {
                                //        Id = message.id,
                                //        ChannelId = chat.id,
                                //        Content = message.message + @" : " + url,
                                //        Type = EnChannelMessage.WebPage,
                                //        Views = message.views ?? 0,
                                //    });
                                //    break;
                        }
                    }
                }
            }
            return _resultMessages;
        }

        //public virtual async Task<string> GetLastMessageFromUser(string sUserName)
        //{
        //    string sResult;
        //    var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
        //    await client.ConnectAsync();
        //    var normalizedUser = (sUserName.StartsWith("@") ?
        //        sUserName.Substring(1, sUserName.Length - 1) :
        //        sUserName).ToLower();
        //    var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
        //    var user = dialogs.Users
        //        .Where(x => x.GetType() == typeof(TLUser))
        //        .OfType<TLUser>()
        //        .FirstOrDefault(x => x.Username != null && x.Username.ToLower() == normalizedUser);

        //    TLAbsMessages tlAbsMessages = await client.GetHistoryAsync(new TLInputPeerUser() {
        //        UserId = user.Id,
        //        AccessHash = user.AccessHash.Value
        //    }, 0, -1, 100);
        //    TLMessages tlMessages = (TLMessages)tlAbsMessages;
        //    TLMessage lastmessage = (TLMessage)tlMessages.Messages[0];
        //    sResult = lastmessage.FromId.ToString() + ":" + lastmessage.Message;
        //    return sResult;
        //}
        public virtual async Task<TLMessage> GetLastMessageFromUser(string sUserName)
        {
            TLMessage lastmessage = null;
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var normalizedUser = (sUserName.StartsWith("@") ?
                sUserName.Substring(1, sUserName.Length - 1) :
                sUserName).ToLower();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            var user = dialogs.Users
                .Where(x => x.GetType() == typeof(TLUser))
                .OfType<TLUser>()
                .FirstOrDefault(x => x.Username != null && x.Username.ToLower() == normalizedUser);

            TLAbsMessages tlAbsMessages = await client.GetHistoryAsync(new TLInputPeerUser()
            {
                UserId = user.Id,
                AccessHash = user.AccessHash.Value
            }, 0, -1, 100);
            if (tlAbsMessages.GetType() == typeof(TLMessagesSlice))
            {
                var castMessages = (TLMessagesSlice)tlAbsMessages;
                lastmessage = (TLMessage)castMessages.Messages[0];
            }
            else if (tlAbsMessages.GetType() == typeof(TLMessages))
            {
                TLMessages tlMessages = (TLMessages)tlAbsMessages;
                lastmessage = (TLMessage)tlMessages.Messages[0];
            }
            return lastmessage;
        }
        public virtual async Task MakeAuthAsync(string code)
        {
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var user = await client.MakeAuthAsync(PhoneNumber, phoneCodeHash, code);
        }
        public virtual async Task SendMessage(string toNumber, string message)
        {
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();

            // this is because the contacts in the address come without the "+" prefix
            var normalizedNumber = toNumber.StartsWith("+") ?
                toNumber.Substring(1, toNumber.Length - 1) :
                toNumber;



            var user = dialogs.Users
               .OfType<TLUser>()
               .FirstOrDefault(x => x.Phone == normalizedNumber);
            await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id, AccessHash = user.AccessHash.Value }, message);
        }
        public virtual async Task SendMessageToUser(string toUserName, string message)
        {
            var client = new TLSharp.Core.TelegramClient(apiId, apiHash);
            await client.ConnectAsync();
            var normalizedUser = (toUserName.StartsWith("@") ?
                toUserName.Substring(1, toUserName.Length - 1) :
                toUserName).ToLower();
            var dialogs = (TLDialogs)await client.GetUserDialogsAsync();
            var user = dialogs.Users
                .Where(x => x.GetType() == typeof(TLUser))
                .OfType<TLUser>()
                .FirstOrDefault(x => x.Username != null && x.Username.ToLower() == normalizedUser);
            if (user != null)
            {
                await client.SendTypingAsync(new TLInputPeerUser() { UserId = user.Id, AccessHash = user.AccessHash.Value });
                await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id, AccessHash = user.AccessHash.Value }, message);
            }

            //await client.SendMessageAsync(new TLInputPeerUser() {  UserId = user.Id, AccessHash = user.AccessHash.Value }, message);


            //send message
            //await client.SendMessageAsync(new TLInputPeerChannel() { ChannelId = chat.Id, AccessHash = chat.AccessHash.Value }, "OUR_MESSAGE");
            //var result = await client.SearchUserAsync(normalizedUser, 10);
            //if (result.Users.Count > 0)
            //{
            //    TLUser user = (TLUser)result.Users[0];
            //    await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, message);
            //}
            //var normalizedNumber1 = toUserName.StartsWith("@") ?
            //    toUserName.Substring(1, toUserName.Length - 1) :
            //    toUserName;

            //var user = result.Users
            //   .OfType<TLUser>()
            //   .FirstOrDefault(x => x.Username == toUserName);
            //await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, message);
        }
    }
}
