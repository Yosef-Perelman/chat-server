using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Join()
        {
            await Clients.All.SendAsync("NewUser", "welcome ");
        }

        public async Task AddedContact()
        {
            await Clients.All.SendAsync("ReciveContact", "receive new contact");
        }

        public async Task AddedMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage", "receive new message");
        }
    }
}