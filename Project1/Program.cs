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


            //string filename = "Canadacities-XML";
            //string filetype = "xml";



            //string filename = "Canadacities-JSON";
            //string filetype = "json";
            
            //new dict and list
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Dictionary<string, string>> list = new();

            string filename = "Canadacities.csv";
            string filetype = "csv";

            //read file using streamreader
            StreamReader reader = new StreamReader(filename);

            int linecount = 0;
            string line;
            int numId = 0;

            //readline
            while ((line = reader.ReadLine()) != null)
            {
                //split line at ',' cause that is how scv files are saved as
                string[] parts = line.Split(',');
                numId++;
                //add values to dict
              //  Console.WriteLine(parts[0] + " " + parts[1] + " " + parts[2] + " " + parts[3] + " " + parts[4] + " " + parts[5] + " " + parts[6] + " " + parts[7] + " " + parts[8]);
                //this might be a work around for trying not to do <int, string> (i mean we r suppose to use a generic dictioary right? idk
                dict.Add("_"+numId, parts[0] + "\n" + parts[1] + "\n" + parts[2] + "\n" + parts[3] + "\n" + parts[4] + "\n" + parts[5] + "\n" + parts[6] + "\n" + parts[7] + "\n" + parts[8] + "\n");

                linecount++;
                //just after 9 add dict (9 is a rand number)
                if(linecount == 9)
                {
                    list.Add(dict);
                }
            }

            //Console.WriteLine(dict.Count); //251 in dict
            //Console.WriteLine(list.Count); // and 1 in list (as a massive string)

            //new list that should contain the cityinfo
            List<string> newcityinfo = new();
            string cityInfo = "";

            //foreach(var pair in dict)
            //{
            //   // Console.WriteLine(pair.Value);
            //    if (pair.Value.Contains("Bella Bella"))
            //    {
            //        Console.WriteLine(pair.Value);
            //    }
            //}

            for (int i = 0; i < list.Count; ++i)
            {

                foreach (var pair in list[i])
                {
                    // Console.WriteLine(pair.Key + " : " + pair.Value);
                    // Console.WriteLine(pair.Value);

                    //for the city bella 
                    if (pair.Value.Contains("Bella Bella"))
                    {
                        cityInfo = pair.Value; //ex: 

                        //split cityinfo at the newline
                        string[] splitcityinfo = cityInfo.Split("\n");

                        //then add the city info to list
                        for (int j = 0; j < splitcityinfo.Length; ++j)
                        {
                            newcityinfo.Add(splitcityinfo[j]);
                        }
                        // Console.WriteLine(cityname);
                    }

                }

            }
            //  Console.WriteLine(newcityinfo[0]);
            //this contains:
            //city,city_ascii,lat,lng,country,region,capital,population,id
            //in that order
            for (int i = 0; i < newcityinfo.Count; ++i)
            {
                Console.WriteLine(newcityinfo[i]);
            }

            // dict.Add(parts[0], parts[1]);

            //Statistics stats = new Statistics(filename, filetype);

            //stats.DisplayCityInformation("Deer Lake"); //has a duplicate
            //stats.DisplayCityInformation("Tuktoyaktuk");
            //Console.WriteLine();
            //stats.DisplayLargestPopulationCity();
            //Console.WriteLine();
            //stats.DisplaySmallestPopulationCity();
            //Console.WriteLine();
            //stats.CompareCitiesPopulation("Port Hardy", "Happy Valley - Goose Bay");
            //Console.WriteLine();
            //stats.DisplayProvincePopulation("Ontario");
            //Console.WriteLine();
            //stats.DisplayProvinceCities("Ontario");
            //stats.RankProvincesByPopulation();


            //messing around with csv
            //var dict = File.ReadLines(filename).Select(line => line.Split(',')).ToDictionary(line => line[0], line => line[1]);

            //foreach(var kvp in dict)
            //{
            //    Console.WriteLine(kvp.Key +  "  "+kvp.Value);
            //}
        }
        }
}