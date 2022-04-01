﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DummyBot
{
   
    public class JsonSerialization
    {
        public static string cmd;
        public static string token;
        public static string str_json_output;
        public static string jsonconfigfilename = "Config.json";
        
        
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
                            str_json_output = read_json_file_jr.ReadAsString();
                            //Console.WriteLine(str_json_output);
                            //Console.ReadKey();
                            //Console.WriteLine(str_json_output.Length);
                            //Console.WriteLine(str_json_output);
                            //Console.ReadKey();
                            //Console.WriteLine(token);
                            //Console.ReadKey();

                            
                            

                            /* Testing
                            Console.WriteLine(token);
                            Console.ReadKey();
                            */
                        }
                    }
                }
            }

            else
            {
                using FileStream create_json_file_fs = File.Create(jsonconfigfilename);
                using StreamWriter create_json_file_sw = new StreamWriter(create_json_file_fs);
                using JsonWriter create_json_file_jw = new JsonTextWriter(create_json_file_sw);

                create_json_file_jw.Formatting = Formatting.Indented;

                create_json_file_jw.WriteStartObject();
                create_json_file_jw.WritePropertyName("Token");
                create_json_file_jw.WriteValue("Enter Token here");
                create_json_file_jw.WriteEndObject();

                if(File.Exists(jsonconfigfilename))
                {
                    Console.WriteLine("Config.json was created");
                    Console.WriteLine("Press a key to exit");
                    Console.ReadKey();

                    Environment.Exit(0);
                }



                //Legacy - 25/03/2022 
                //await System.Text.Json.JsonSerializer.SerializeAsync(create_json_file_fs, "Token: ");

                //await create_json_file_fs.DisposeAsync();
            }
               
           
            
            
            
        }
    }
}