using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using YamlDotNet.Serialization;



namespace NETRMSI_Bot
{

    public class YamlSerialization
    {
        public static string cmd;
        public static string token;
        public static string str_json_output;
        public static string yamlconfigfilename = "Config.yaml";


        public static async void Config_Yaml()
        {
            if (File.Exists(yamlconfigfilename))
            {
                //deserialization code here

            }

            else
            {
                using FileStream fs = new FileStream(yamlconfigfilename, FileMode.Create) ;

                var botconfig = new Yamlconfig.botconfig
                {
                    token = "",
                };

                var server_0 = new Yamlconfig.server_0
                {
                    name = "",
                    ipaddress = "",
                };

                if (File.Exists(yamlconfigfilename))
                {
                    Console.WriteLine("Config.json was created");
                    Console.WriteLine("Press a key to exit");
                    Console.ReadKey();

                    Environment.Exit(0);
                }



               
            }





        }
    }
}
