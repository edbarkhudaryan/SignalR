using BusinessLayer.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Hubs
{
    public class NotificationHub:Hub
    {
        public User User = new User();
        public Task SendMessage(User user /*string user, string message*/)
        {
           
           // return Clients.All.SendAsync("ReceiveMessage", user, message);
            return Clients.All.SendAsync("ConnectionChat", user.Name,user.Message,user.SMSReciver);
        }

    }
}
