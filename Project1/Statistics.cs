using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq; 

namespace Project1
{
    public class Statistics
    {
        //dictionary generic type?
        List<Dictionary<string, string>> citycatalog = new();
        DataModeler modeler = new();
        List<cityinfo> cityinfo = new();
        cityinfo info;

        //filetype = JSON, XML, CSV
        public Statistics(string filename, string filetype) {

            string fileType = "." + filetype;
            string fullfilename = filename + fileType;


            //populate the list of cityinfo 
            int cityid = 0;
            string cityname = "";
            string cityAscii = "";
            int population = 0;
            string province = "";
            double latitude = 0;
            double longitude = 0;

            if (filetype.Contains("xml"))
            {

                citycatalog.AddRange(modeler.ParseFile(fullfilename, filetype));
                for (int i = 0; i < citycatalog.Count; ++i)
                {

                    foreach (var pair in citycatalog[i])
                    {
                        //  Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");

                        //takes data from list of dictionary data and puts it into a list of cityinfo
                        if (pair.Key == "id_" + i)
                        {
                            cityid = Int32.Parse(pair.Value);

                        }
                        else if (pair.Key == "city_" + i)
                        {
                            cityname = pair.Value;

                        }
                        else if (pair.Key == "city_ascii_" + i)
                        {
                            cityAscii = pair.Value;
                        }
                        else if (pair.Key == "population_" + i)
                        {
                            population = Int32.Parse(pair.Value);
                        }
                        else if (pair.Key == "region_" + i)
                        {

                            province = pair.Value;

                        }
                        else if (pair.Key == "lat_" + i)
                        {
                            latitude = Double.Parse(pair.Value);
                        }
                        else if (pair.Key == "lng_" + i)
                        {
                            longitude = Double.Parse(pair.Value);
                        }


                    }

                    cityinfo.Add(new cityinfo(cityid, cityname, cityAscii, population, province, latitude, longitude));



                }
            }

            //say if the user clicks on a file that is a json
            if(filetype.Contains("json"))
            { 

                //call the parse method for json
                //don't think this is right
                citycatalog.AddRange(modeler.ParseFile(fullfilename, filetype));
                //modeler.ParseFile(fullfilename, filetype);

              

                for (int i = 0; i < citycatalog.Count; ++i)
                {
                    //Console.WriteLine($"[{i}]");

                    if (citycatalog[i] == null)
                    {

                        Console.WriteLine("[null]");
                    }
                    else
                        foreach (var pair in citycatalog[i])
                        {
                            //  Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");

                            //takes data from list of dictionary data and puts it into a list of cityinfo
                            if (pair.Key == "id")
                            {
                                cityid = Int32.Parse(pair.Value);

                            }
                            else if (pair.Key == "city")
                            {
                                cityname = pair.Value;

                            }
                            else if (pair.Key == "city_ascii")
                            {
                                cityAscii = pair.Value;
                            }
                            else if (pair.Key == "population")
                            {
                                population = Int32.Parse(pair.Value);
                            }
                            else if (pair.Key == "region")
                            {

                                province = pair.Value;

                            }
                            else if (pair.Key == "lat")
                            {
                                latitude = Double.Parse(pair.Value);
                            }
                            else if (pair.Key == "lng")
                            {
                                longitude = Double.Parse(pair.Value);
                            }


                        }

                    cityinfo.Add(new cityinfo(cityid, cityname, cityAscii, population, province, latitude, longitude));
                    // Console.WriteLine(cityinfo[0].city);

                    // cityinfo.Add(info);
                }
            }

            //put the data from parse to dictionary?
             

        }

        
        //display cition info 
        public void DisplayCityInformation(string cname)
        { 


            //display data:
            for (int i = 0; i < cityinfo.Count; i++)
            {
                // Console.WriteLine(cityinfo[i].city);
                if (cityinfo[i].city == cname)
                {
                    Console.WriteLine($"CityID: {cityinfo[i].CityID}");
                    Console.WriteLine($"CityName: {cityinfo[i].city} ");
                    Console.WriteLine($"City_Ascii: {cityinfo[i].CityAscii} ");
                    Console.WriteLine($"Population: {cityinfo[i].Population} ");
                    Console.WriteLine($"Province: {cityinfo[i].Province} ");
                    Console.WriteLine($"Latitude: {cityinfo[i].Latitude}");
                    Console.WriteLine($"Longitude: {cityinfo[i].Longitude}");
                }
            }

        }

        //city methods

        //suppose to take in some sort of paramter?
        //returns the privince with the population
        public void DisplayLargestPopulationCity()
        {
            int largestPopulation = 0;
            string largestPopulationProvince = "";
            string largestPopulationCity = "";
            //display data:
            for (int i = 0; i < cityinfo.Count; i++)
            {
                // Console.WriteLine(cityinfo[i].city);

               // cityinfo[i].Population = largestPopulation;

                if (cityinfo[i].Population > largestPopulation)
                {
                     largestPopulation = cityinfo[i].Population;
                    largestPopulationProvince = cityinfo[i].Province;
                    largestPopulationCity = cityinfo[i].city;
                }
            }

            Console.WriteLine($"The Province of {largestPopulationProvince} has the largest population of {largestPopulation} in the city of {largestPopulationCity}");
        }


        //displays the province with the smallest population
        public void DisplaySmallestPopulationCity()
        {
            //we can set 100000000 as a placeholder
            //there might be a better way of doing this
            int smallestPopulation = 10000000;
            string smallestPopulationProvince = "";
            string smallestPopulationCity = "";

            //display data:
            for (int i = 0; i < cityinfo.Count; i++)
            {

                if (cityinfo[i].Population < smallestPopulation)
                {
                    smallestPopulation = cityinfo[i].Population; 
                    smallestPopulationProvince= cityinfo[i].Province;
                    smallestPopulationCity = cityinfo[i].city;
                }
                 
            }

            Console.WriteLine($"The Province of {smallestPopulationProvince} has the smallest population of {smallestPopulation} in the city of {smallestPopulationCity}");
        }


        //compaort 2 city populations
        public void CompareCitiesPopulation(string city1, string city2)
        {
            int city1Population = 0, city2Population = 0;

            for(int i = 0; i < cityinfo.Count; i++)
            {
                if (cityinfo[i].city == city1)
                {
                    city1Population = cityinfo[i].Population;
                }

                if (cityinfo[i].city == city2)
                {
                    city2Population = cityinfo[i].Population;
                }


            }

            if(city1Population > city2Population)
            {
                Console.WriteLine($"The population of {city1} is larger with the population of {city1Population}");
                Console.WriteLine($"Compared to  {city2} with a  population of {city2Population}");
            }
            else
            {
                Console.WriteLine($"The population of {city2} is larger with the population of {city2Population}");
                Console.WriteLine($"Compared to  {city1} with a  population of {city1Population}");
            }
        }



        //province methods

        //display total population of a province
        public void DisplayProvincePopulation(string ProvinceName)
        {
            int totalPopulationOfProvince = 0;

            for(int i = 0; i <cityinfo.Count; i++)
            {
                if (cityinfo[i].Province == ProvinceName)
                {
                    totalPopulationOfProvince += cityinfo[i].Population;
                }
            }

            Console.WriteLine($"The total population of {ProvinceName} is {totalPopulationOfProvince}");
        }


        //display all cities in a province
        public void DisplayProvinceCities(string ProvinceName)
        {
            Console.WriteLine($"All cities in the province of {ProvinceName}");

            for (int i = 0; i < cityinfo.Count; i++)
            {
                if (cityinfo[i].Province == ProvinceName)
                {
                    Console.WriteLine(cityinfo[i].city);
                }
            }
        }

        //order by pop
        public void RankProvincesByPopulation()
        {

            //List<int> population = new List<int>();
            Dictionary<string, int> population = new();
            for(int i = 0; i < cityinfo.Count; i++)
            {
                population.Add(cityinfo[i].Province ,cityinfo[i].Population);
            }


            //population.Sort();

          foreach(var pair in population) {
                Console.WriteLine(pair.Key + pair.Value);
            }

        }
    }
}
