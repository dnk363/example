﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Example.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Connect", Context.User.Identity.Name);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Disconnect", Context.User.Identity.Name);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
