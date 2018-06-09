using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
namespace TLSharp.Example
{
    public class TelegramApi
    {
        int apiId = 193474;
        string apiHash = "7a74bfa34444ba1c869159957bb21a08";
        string phoneCodeHash = "";
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
            var result = await client.GetContactsAsync();

            // this is because the contacts in the address come without the "+" prefix
            var normalizedNumber = toNumber.StartsWith("+") ?
                toNumber.Substring(1, toNumber.Length - 1) :
                toNumber;



            var user = result.Users
               .OfType<TLUser>()
               .FirstOrDefault(x => x.Phone == normalizedNumber);
            await client.SendMessageAsync(new TLInputPeerUser() { UserId = user.Id }, message);
        }
    }
}
