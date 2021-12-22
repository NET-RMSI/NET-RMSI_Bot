using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;




namespace DummyBot
{
    class Program
    {
        public string serverstat_delta1_bedrock;
        public string serverstat_delta1_jellyfin;


        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient client;
        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.MessageReceived += CommandHandler;
            client.Log += Log;


            var token = File.ReadAllText("Token.txt");




            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private Task CommandHandler(SocketMessage message)
        {
            string command = "";
            int lengthOfCommand = -1;


            if (!message.Content.StartsWith("!"))
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();


            if (command.Equals("jellyfin"))
            {
                ServerStatusCheck();

                message.Channel.SendMessageAsync(message.Author.Mention + "Pinging Servers... " + "\n" + serverstat_delta1_jellyfin);



            }


            return Task.CompletedTask;
        }

        public void ServerStatusCheck()
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect("86.14.65.74", 8096);

                serverstat_delta1_jellyfin = "Jellyfin@Deltaserver1: Online";

            }
            catch (Exception)
            {
                serverstat_delta1_jellyfin = "Jellyfin@Deltaserver1: Offline";
            }
        }
    }
}

