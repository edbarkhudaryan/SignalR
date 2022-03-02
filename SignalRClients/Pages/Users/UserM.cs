using BusinessLayer.Entities;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRClients.Pages.Users
{
    public class UserM
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string ConnectionId { get; set; }
        public string SMSReciver { get; set; }

        private List<User> list = new List<User>();
        // public User user = new User();
        private static HubConnection hubConnection;

        public UserM()
        {

        }

        public UserM(int? id = null, string name = null, string message = null, string connectionId = null, string smsReciver = null)
        {
            this.ID = id;
            this.Name = name;
            this.Message = message;
            this.ConnectionId = connectionId;
            this.SMSReciver = SMSReciver;
        }

        public async Task ConnectionChat()
        {
            hubConnection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/notification")
            .Build();

            //  hubConnection.On<User>("send", message => this.Message);





            await hubConnection.StartAsync();

            ConnectionId = hubConnection.ConnectionId;

            hubConnection.On<string>("send", message => Console.WriteLine($"{Name} send  :{message}"));

            User user = new User();

            list = new List<User>
            {
                new User(name: Name, message: Message, connectionId: ConnectionId),
                new User(name: Name, message: Message, connectionId: ConnectionId),
                new User(name: Name, message: Message, connectionId: ConnectionId),
            };


            this.ConnectionId = GetConnectionIDByName(Name);

            if (this.ConnectionId==user.ConnectionId)
            {
                await hubConnection.SendAsync("SendMessage", Name, Message, SMSReciver);
            }
           

        }

        public async Task SendMessageUsers()
        {
            //while (!isExit)
            //{
            //    var message = Console.ReadLine();
            //    if (message != "exit")
            //        await hubConnection.SendAsync("SendMessage", message);

            //    else
            //        isExit = true;
            //}

        }

        public string GetConnectionIDByName(string name = null)
        {
            if (name != null)
            {

            }
            User result = list.Find(x => x.Name == name);

            string connectionID = result.ConnectionId;

            return connectionID;

        }
    }
}
