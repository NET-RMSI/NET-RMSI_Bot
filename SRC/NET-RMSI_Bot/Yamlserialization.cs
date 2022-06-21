using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using YamlDotNet.Serialization;





namespace NETRMSI_Bot
{

    public class YamlSerialization
    {
        public static string contents;
        public static string token;
        public static string str_json_output;
        public static string yamlconfigfilename = "Config.yaml";


        public static void Config_Yaml()
        {
            var botconfig = new Yamlconfig.botconfig
            {
                token = "Insert bot token here",
            };

            var server_0 = new Yamlconfig.server_0
            {
                name = "Name of server",
                ipaddress = "Ipaddress of server",
            };

            if (File.Exists(yamlconfigfilename))
            {
                using (StreamReader sr = new StreamReader(yamlconfigfilename))
                {
                     contents = sr.ReadToEnd();
                    
                }
                var input = new StringReader(contents);

                var deserializer = new DeserializerBuilder().Build();
                var botconfigcontents = deserializer.Deserialize<Yamlconfig.botconfig>(input);
                token = botconfigcontents.token;
                

                
            }

            else
            {
                using FileStream fs = new FileStream(yamlconfigfilename, FileMode.Create);
                fs.Dispose();

                

                

                var serializer = new SerializerBuilder().Build();
                var yaml = serializer.Serialize(botconfig);

                using (StreamWriter sw = new StreamWriter(yamlconfigfilename))
                {
                    sw.WriteLine(yaml);
                }





                if (File.Exists(yamlconfigfilename))
                {
                    Console.WriteLine("Config.YAML was created");
                    Console.WriteLine("Please fill out the Config.YAML file with appropriate information");
                    Console.WriteLine("Press a key to exit");
                    Console.ReadKey();

                    Environment.Exit(0);
                }
                


               
            }





        }
    }
}
