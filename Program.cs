using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace StudyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GetJsonCase();
            GetRandomCodeCase();
        }

        static void GetRandomCodeCase()
        {
            Regex regex = new("^[ACDEFGHKLMNPRTXYZ234579]{8}$");
            List<string> codes = new();
            while (codes.Count < 1000)
            {
                StringBuilder code = RandomString();
                if (regex.IsMatch(code.ToString()) && !codes.Contains(code.ToString()))
                {
                    codes.Add(code.ToString());
                }
            }
        }
        static StringBuilder RandomString()
        {
            StringBuilder kelime = new StringBuilder();
            var rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                kelime.Append((char)rnd.Next('2', 'Z'));
            }
            return kelime;
        }
        static void GetJsonCase()
        {
            string jsonString = File.ReadAllText("data.json");

            JArray jsonData = JsonConvert.DeserializeObject<JArray>(jsonString);
            JToken description = jsonData[0]["description"];
            JToken boundingPoly = jsonData[0]["boundingPoly"];
            JToken vertices = boundingPoly["vertices"];

            int x = (int)vertices[0]["x"];
            int y = (int)vertices[0]["y"];
        }
    }
}
