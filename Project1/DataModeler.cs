using System.Collections.Generic;
using System.Runtime;
using System.Xml;
using System.Xml.Linq;

namespace Project1
{
   
    using Dictionary_T = Dictionary<string, List<CityInfo>>;

  

    public class DataModeler
    {
        const string JSON = "json";
        const string XML = "xml";
        const string CSV = "csv";

        protected Dictionary_T ValueList = new();

        public delegate void Parse(string fileName);

        public Parse? GetParse;

        private void ParseJSON(string fileName)
        {

        }

        private void ParseXML(string fileName)
        {
            XmlDocument doc;
            if (File.Exists(fileName))
            {
                doc = new XmlDocument();
                doc.Load(fileName);

            }
            else 
                throw new FileNotFoundException($"File named {fileName} not found.", fileName);

            CityInfo cityInfo;

             
            

            XDocument docs = XDocument.Load(fileName);

            List<XElement> CanadaCities = docs.Descendants("CanadaCities").ToList();

            //CityID = cityid;
            //CityName = cityname;
            //CityAscii = cityacii;
            //Population = population;
            //Province = province;
            //location = new Location(lat, lng);

            
            
            string cityNames = "";
            string cityAsciis = "";
            double cityLats = 0.0;
            double cityLngs = 0.0;
            string cityRegions = "";
            int cityPopulations = 0;
            int cityIDs = 0;



            //foreach (var item in CanadaCities)
            //{
            //    foreach (XElement citydes in item.Descendants("CanadaCity"))
            //    {


            //        cityInfo = new CityInfo
            //        (
            //        cityIDs,
            //        cityNames,
            //        cityAsciis,
            //        cityPopulations,
            //        cityRegions,
            //        cityLats,
            //        cityLngs
            //        );

            //        //Console.WriteLine();
            //        //Console.WriteLine(cityInfo);
            //        //Console.WriteLine();
            //    }
            //}
            foreach (var item in CanadaCities)
            {
                foreach (XElement citydes in item.Descendants("CanadaCity"))
                {
                    foreach (XElement name in citydes.Descendants("city"))
                    {

                        cityNames = name.Value;

                    }
                    foreach (XElement ascii in citydes.Descendants("city_ascii"))
                    {

                        cityAsciis = ascii.Value;

                    }
                    foreach (XElement lats in citydes.Descendants("lat"))
                    {

                        cityLats = double.Parse(lats.Value);

                    }
                    foreach (XElement lng in citydes.Descendants("lng"))
                    {

                        cityLngs = double.Parse(lng.Value);

                    }
                    foreach (XElement region in citydes.Descendants("region"))
                    {

                        cityRegions = region.Value;

                    }
                    foreach (XElement population in citydes.Descendants("population"))
                    {

                        cityPopulations = int.Parse(population.Value);


                    }
                    foreach (XElement ids in citydes.Descendants("id"))
                    {

                        cityIDs = int.Parse(ids.Value);

                    }

                    cityInfo = new CityInfo
                    (
                    cityIDs,
                    cityNames,
                    cityAsciis,
                    cityPopulations,
                    cityRegions,
                    cityLats,
                    cityLngs
                    );

                    Console.WriteLine();
                    Console.WriteLine(cityInfo);
                    Console.WriteLine();

                    if (!ValueList.ContainsKey(cityInfo.CityName))
                    {
                        ValueList.Add(cityInfo.CityName, new());
                        ValueList[cityInfo.CityName].Add(cityInfo);
                    }
                    else
                    {
                        //Console.WriteLine($"{cityInfo}");
                        ValueList[cityInfo.CityName].Add(cityInfo);
                    }
                }
            }




        }


        private void ParseCSV(string fileName)
        {
            string raw;
            if (File.Exists(fileName))
            {
                raw = File.ReadAllText(fileName).ToString();
            }
            else
                throw new FileNotFoundException($"File named {fileName} not found.", fileName);

            string[] countries = raw.Split("\r\n");

            for (int i = 1; i < countries.Length; i++)
            {
                string[] cityData = countries[i].Split(",");
                CityInfo city;
                if (cityData.Length > 1)
                {
                    city = new CityInfo
                    (
                        int.Parse(cityData[8]),
                        cityData[0],
                        cityData[1],
                        int.Parse(cityData[7]),
                        cityData[5],
                        double.Parse(cityData[2]),
                        double.Parse(cityData[3])
                    );

                    if (!ValueList.ContainsKey(city.CityName))
                    {
                        ValueList.Add(city.CityName, new());
                        ValueList[city.CityName].Add(city);
                    }
                    else
                    {
                        Console.WriteLine($"{city}");
                        ValueList[city.CityName].Add(city);
                    }
                }
            }
        }

        public Dictionary_T ParseFile(string fileName, string type)
        {
            fileName = $"{fileName}.{type}";
            switch (type.ToLower())
            {
                case JSON:
                    GetParse = ParseJSON;
                    break;
                case XML:
                    GetParse = ParseXML;
                    break;
                case CSV:
                    GetParse = ParseCSV;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
            GetParse!.Invoke($"../../../data/{fileName}");
            //"\Canadacities.csv"
            return ValueList;
        }
    }
}