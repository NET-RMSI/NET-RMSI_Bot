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
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NETRMSI_Bot
{
    public class Serverstatus
    {
        public static int pingtimeout = 60000;
        public static string serverstat_flarenet_nextcloud;
        public static string serverstat_flarenet_nextcloud_advstats;
        public static string serverstat_delta1_minecraftjava_personalsrv;

        public static void Serverping_Nextcloud()
        {
            Ping nextcloudstatus = new Ping();
            PingReply nextcloudreply = nextcloudstatus.Send("nextcloud.flarenet.co.uk", pingtimeout);

            if (nextcloudreply.Status == IPStatus.Success)
            {
                serverstat_flarenet_nextcloud = "> https://nextcloud.flarenet.co.uk - Online";

                serverstat_flarenet_nextcloud_advstats = @"Address: " + nextcloudreply.Address.ToString() + Environment.NewLine
                                                            + @"Buffer Size: " + nextcloudreply.Buffer.ToString() + Environment.NewLine
                                                            + @"RoundTrip time: " + nextcloudreply.RoundtripTime.ToString() + Environment.NewLine
                                                            + @"Time to live: " + nextcloudreply.Options.Ttl.ToString();



            }

            else
            {
                serverstat_flarenet_nextcloud = "> https://nextcloud.flarenet.co.uk - Offline";
            }

            
            
            
            //Legacy Code - 11/03/2022
            /*TcpClient tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect("00.00.00.00", 8096);

                serverstat_delta1_jellyfin = "Jellyfin@Deltaserver1: Online";

            }
            catch (Exception)
            {
                serverstat_delta1_jellyfin = "Jellyfin@Deltaserver1: Offline";
            }*/
            

        }

        public static void Serverping_minecraftjava_personalsrv()
        {
            /*TcpClient tcpClient = new TcpClient();

            try
            {
                tcpClient.Connect("00.00.00.00", 25565);

                serverstat_delta1_minecraftjava_personalsrv = "Minecraft-personalsrv@Deltaserver1: Online";

            }
            catch (Exception)
            {
                serverstat_delta1_minecraftjava_personalsrv = "Minecraft-personalsrv@Deltaserver1: Offline";
            }*/
        }
    }
}
