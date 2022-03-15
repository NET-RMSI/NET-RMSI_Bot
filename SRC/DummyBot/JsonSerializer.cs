using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DummyBot
{
    public class JsonSerialization
    {
        

        public static string jsonconfigfilename = "Config.json";
        //public static string jsonconfigfile;
        public static async void Config_Json()
        {
            if(File.Exists(jsonconfigfilename))
            {
               //Read Json contents to parse; api token, server addresses etc
            }

            else
            {
                using FileStream create_json_string = File.Create(jsonconfigfilename);
                await JsonSerializer.SerializeAsync(create_json_string, "Token: ");

                await create_json_string.DisposeAsync();
            }
               
           
            
            
            
        }
    }
}
