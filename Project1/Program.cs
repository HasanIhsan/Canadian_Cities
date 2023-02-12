using System.Collections.Generic;
using System.Data;
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


            //string filename = "Canadacities-XML";
            //string filetype = "xml";



            //string filename = "Canadacities-JSON";
            //string filetype = "json";
             

            //string filename = "Canadacities";
            //string filetype = "csv";

            Statistics stats = new("Canadacities-XML", "xml");


           
           // Statistics stats = new Statistics(filename, filetype);

            //stats.DisplayCityInformation("Deer Lake"); //has a duplicate
            stats.DisplayCityInformation("Tuktoyaktuk");
            //Console.WriteLine();
            stats.DisplayLargestPopulationCity();
            //Console.WriteLine();
            //stats.DisplaySmallestPopulationCity();
            //Console.WriteLine();
            //stats.CompareCitiesPopulation("Port Hardy", "Happy Valley - Goose Bay");
            //Console.WriteLine();
            //stats.DisplayProvincePopulation("Ontario");
            //Console.WriteLine();
            //stats.DisplayProvinceCities("Ontario");
            //stats.RankProvincesByPopulation();

 
        }
    }
}