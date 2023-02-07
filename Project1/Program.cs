using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace Project1
{


    internal class Program
    {

        static void Main(string[] args)
        {

            //DataModeler m = new();

            //m.ParseJSON("Canadacities-JSON.json");

            //Console.WriteLine(m.count());   

            string readData = File.ReadAllText("Canadacities-JSON.json");


            List<Dictionary<string, string>> ValueList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(readData);

            Dictionary<string, string> list = JsonSerializer.Deserialize<Dictionary<string, string>>(readData);

            foreach (var pair in list)
            {
                Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");

            }

            //for (int i = 0; i < ValueList.Count; ++i)
            //{
            //    Console.WriteLine($"[{i}]");

            //    if (ValueList[i] == null)
            //    {

            //        Console.WriteLine("[null]");
            //    }
            //    else
            //        foreach (var pair in ValueList[i])
            //        {
            //            Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");

            //        }



            //}
        }
    }
}