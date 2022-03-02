using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static HubConnection HubConnection;
        static async Task Main(string[] args)
         {

            string conncectionID;
            HubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/notification")
                .Build();

            await HubConnection.StartAsync();

            
            
            
            
            conncectionID = HubConnection.ConnectionId;

            HubConnection.On<string>("send", message => Console.WriteLine($"Message from server :{message}"));

           

           
            bool isExit = false;

            while (!isExit)
            {
                var message =    Console.ReadLine();
                if (message != "exit")
                    
                    await HubConnection.SendAsync("SendMessage", message);
                else
                    isExit = true;
            }

            Console.ReadLine();
        }
    }
}
