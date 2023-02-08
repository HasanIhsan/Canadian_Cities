using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Statistics
    {
        //dictionary generic type?
        List<Dictionary<string, string>> citycatalog = new();
        DataModeler modeler = new();

        //filetype = JSON, XML, CSV
        public Statistics(string filename, string filetype) {

            string fileType = "." + filetype;
            string fullfilename = filename + fileType;

           


            //say if the user clicks on a file that is a json
            if(filetype.Contains("json"))
            {
                DataModeler.ParseJson parsejson = modeler.ParseJSON;

                //call the parse method for json
                //don't think this is right
                citycatalog.AddRange(modeler.ParseFile(fullfilename, filetype));
               //modeler.ParseFile(fullfilename, filetype);

            }

            //put the data from parse to dictionary?
             

        }

        public void DisplayCityInformation(string cname)
        {

            List<cityinfo> cityinfo = new();

            int cityid = 0;
            string cityname = "";
            string cityAscii = "";
            int population = 0;
            string province = "";
            double latitude = 0;
            double longitude = 0;

            cityinfo info;

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
                       
                       
                         
                        //Console.WriteLine(cityid + " " + cityname);

                        cityinfo.Add( new cityinfo(cityid, cityname, cityAscii, population, province, latitude, longitude));

                        //  s.setCity(pair.Value);

                        
                    }

              
                // Console.WriteLine(cityinfo[0].city);

               // cityinfo.Add(info);
            }
            Console.WriteLine(citycatalog[0].Values.First());
            //Console.WriteLine(cityinfo[2].city);



            //display data:
            //for (int i = 0; i < cityinfo.Count; i++)
            //{
            //    // Console.WriteLine(cityinfo[i].city);
            //    if (cityinfo[i].city == cname)
            //    {
            //        Console.WriteLine(cityinfo[i].CityID);
            //        Console.WriteLine(cityinfo[i].city);
            //        Console.WriteLine(cityinfo[i].CityAscii);
            //        Console.WriteLine(cityinfo[i].Population);
            //        Console.WriteLine(cityinfo[i].Province);
            //        Console.WriteLine(cityinfo[i].Latitude);
            //        Console.WriteLine(cityinfo[i].Longitude);
            //    }
            //}

        }
    }
}
