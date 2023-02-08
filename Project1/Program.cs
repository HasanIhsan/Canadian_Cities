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

            // m.ParseJSON("Canadacities-JSON.json");

            //Console.WriteLine(m.count());   



            //string filename = "Canadacities.csv";
            //string filetype = "xml";


            //var dict = File.ReadLines(filename).Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);

            //foreach(var kvp in dict)
            //{
            //    Console.WriteLine(kvp.Key +  "  "+kvp.Value);
            //}
            string filename = "Canadacities-JSON";
            string filetype = "json";

            Statistics stats = new Statistics(filename, filetype);

           // stats.DisplayCityInformation("Deer Lake");
            stats.DisplayCityInformation("Tuktoyaktuk");
            //Console.WriteLine();  
            //stats.DisplayLargestPopulationCity();
            //Console.WriteLine();
            //stats.DisplaySmallestPopulationCity();
            //stats.CompareCitiesPopulation("Port Hardy", "Happy Valley - Goose Bay");
            // Console.WriteLine();
            // stats.DisplayProvincePopulation("Ontario");
            //Console.WriteLine();
            //  stats.DisplayProvinceCities("Ontario");
            // stats.RankProvincesByPopulation();
        }
    }
}