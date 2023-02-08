using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace Project1
{
    public class DataModeler
    {

         
        List<Dictionary<string, string>> ValueList;
     //  public List<cityinfo> cit = new(); //list of cities

        

        public delegate void ParseJson(string file);

        public int count()
        {
            return ValueList.Count;
        }


        public void ParseJSON(string fileName)
        {
            //put all data read from file to string
            string readData = File.ReadAllText(fileName);
           // Console.WriteLine(readData);

             

           

                //for json
                //this is simple code to deserialize json to a list od dictionary 
            ValueList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(readData);

           



        }

        public List<Dictionary<string, string>> ParseFile(string fileName, string filetype)
        {

            if (filetype.Contains("json"))
            {
                ParseJson handler = ParseJSON;

                handler.Invoke(fileName);
            }

            return ValueList;

        }

    }
}