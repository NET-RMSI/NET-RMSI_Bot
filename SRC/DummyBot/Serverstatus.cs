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
    public class Serverstatus
    {
        public static string serverstat_delta1_bedrock;
        public static string serverstat_delta1_jellyfin;
        public static string serverstat_delta1_minecraftjava_personalsrv;

        public static void Serverping_jellyfin()
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

        public static void Serverping_minecraftjava_personalsrv()
        {
            TcpClient tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect("86.14.65.74", 25565);

                serverstat_delta1_minecraftjava_personalsrv = "Minecraft-personalsrv@Deltaserver1: Online";

            }
            catch (Exception)
            {
                serverstat_delta1_minecraftjava_personalsrv = "Minecraft-personalsrv@Deltaserver1: Offline";
            }
        }
    }
}
