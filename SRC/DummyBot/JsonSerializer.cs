using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DummyBot
{
    public class discordcfg
    {
        public string discord_token { get; set; }
    }
    public class JsonSerialization
    {

        public static string token;
        public static string jsonconfigfilename = "Config.json";
        public static string test;
        public static async void Config_Json()
        {
            if(File.Exists(jsonconfigfilename))
            {
                //Read Json contents to parse; api token, server addresses etc
                //Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                
                using FileStream read_json_file_fs = File.Open(jsonconfigfilename, FileMode.Open);
                using StreamReader read_json_file_sr = new StreamReader(read_json_file_fs);
                using JsonReader read_json_file_jr = new JsonTextReader(read_json_file_sr);
                
                {
                    while(read_json_file_jr.Read())
                    {
                          if(read_json_file_jr.TokenType != JsonToken.StartObject)
                        {
                            Newtonsoft.Json.JsonConvert.DeserializeObject<discordcfg>(test);
                            Console.WriteLine(test);
                            Console.ReadKey();
                        }
                    }
                }
            }

            else
            {
                using FileStream create_json_file_fs = File.Create(jsonconfigfilename);
                await System.Text.Json.JsonSerializer.SerializeAsync(create_json_file_fs, "Token: ");

                await create_json_file_fs.DisposeAsync();
            }
               
           
            
            
            
        }
    }
}
