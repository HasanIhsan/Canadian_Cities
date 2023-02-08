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



            string filename = "Canadacities-XML";
            string filetype = "xml";

            //string filename = "Canadacities-JSON";
            //string filetype = "json";

            Statistics stats = new Statistics(filename, filetype);

            stats.DisplayCityInformation("Whitehorse");
            //Console.WriteLine();  
            //stats.DisplayLargestPopulationCity();
            //Console.WriteLine();
            //stats.DisplaySmallestPopulationCity();
            //stats.CompareCitiesPopulation("Port Hardy", "Happy Valley - Goose Bay");
        }
    }
}