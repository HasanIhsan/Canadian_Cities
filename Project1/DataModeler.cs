using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace Project1
{
    public class DataModeler
    {

         
        List<Dictionary<string, string>> ValueList;
       public List<cityinfo> cit = new();

        Dictionary<string, string> values;

        public delegate void ParseJson(string file);

        public int count()
        {
            return ValueList.Count;
        }


        public void ParseJSON(string fileName)
        {
            //put all data read from file to string
            string readData = File.ReadAllText(fileName);
            //Console.WriteLine(readData);

            //string json = @"{""key1"":""value1"",""key2"":""value2""}";

           

                //for json
                ValueList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(readData);

            int cityid = 0;
            string cityname = "";
            string cityAscii = "";
            int population = 0;
            string province = "";
            double latitude = 0;
            double longitude = 0;

            cityinfo info;

            //for (int i = 0; i < ValueList.Count; ++i)
            //{
            //    //Console.WriteLine($"[{i}]");

            //    if (ValueList[i] == null)
            //    {

            //        Console.WriteLine("[null]");
            //    }
            //    else
            //        foreach (var pair in ValueList[i])
            //        {
            //            //Console.WriteLine($"\"{pair.Key}\" : \"{pair.Value}\"");

            //            switch (pair.Key)
            //            {
            //                case "id":
            //                    cityid = Int32.Parse(pair.Value);
            //                    break;
            //                case "city": 
            //                    cityname = pair.Key;
            //                    break;
            //                case "city_ascii":
            //                    cityAscii = pair.Value;
            //                    break;
            //                case "population":
            //                    population= Int32.Parse(pair.Value);
            //                    break;
            //                case "region":
            //                    province = pair.Key;
            //                    break;
            //                case "lat":
            //                    latitude = Double.Parse(pair.Value);
            //                    break;
            //                case "lng":
            //                    longitude = Double.Parse(pair.Value);
            //                    break;


            //            }
 
            //            //Console.WriteLine(cityid + " " + cityname);
            //            info = new cityinfo(cityid, cityname, cityAscii, population, province, latitude, longitude);

            //            //  s.setCity(pair.Value);

            //            cit.Add(info);
            //        }


               
            //}


             
            
        }

        //public Dictionary<T, T> ParseFile<T>(string fileName, string filetype)
        //{
           
        //    if(filetype.Contains(".json"))
        //    {
        //        ParseJson handler = ParseJSON;

        //        handler.Invoke(fileName);
        //    }

        //    return ValueList;

        //}

    }
}