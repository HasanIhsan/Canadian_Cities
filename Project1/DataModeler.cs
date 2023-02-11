using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Project1
{
    public class DataModeler
    {

         
        List<Dictionary<string, string>> ValueList = new();
     //  public List<cityinfo> cit = new(); //list of cities

        

        public delegate void ParseJson(string file);
        public delegate void ParseXml(string file);
        public delegate void ParseCsv(string file);

        public int count()
        {
            return ValueList.Count;
        }


        public void ParseJSON(string fileName)
        {
            //put all data read from file to string
            string readData = File.ReadAllText(fileName);
     
             //for json
            //this is simple code to deserialize json to a list od dictionary 
            ValueList = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(readData);

           



        }

        public void ParseXML(string fileName)
        {

            int addcount = 0;

            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();
            
            //put all data read from file to string
            string readData = File.ReadAllText(fileName);
            XDocument doc = XDocument.Parse(readData);
            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName))
                {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
                addcount++;


                //every 9 values (which is in the file add to list
                //there is prob a better way of doing this
                if(addcount == 9)
                {
                    ValueList.Add(dataDictionary);
                    addcount = 0;
                }
            }

             
            
        }

        public void ParseCSV(string fileName)
        {
            //put all data read from file to string
          
            Dictionary<string, string> dict = new Dictionary<string, string>();

            StreamReader reader = new StreamReader(fileName);

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
                dict.Add("_" + numId, parts[0] + "\n" + parts[1] + "\n" + parts[2] + "\n" + parts[3] + "\n" + parts[4] + "\n" + parts[5] + "\n" + parts[6] + "\n" + parts[7] + "\n" + parts[8] + "\n");

                linecount++;

                //just after 9 add dict (9 is a rand number)
                if (linecount == 9)
                {
                    ValueList.Add(dict);
                }
            }

        }

        public List<Dictionary<string, string>> ParseFile(string fileName, string filetype)
        {

            if(filetype.Contains("csv"))
            {
                
                ParseCsv handler = ParseCSV;
                handler.Invoke(fileName);
            }

            if (filetype.Contains("json"))
            {
                ParseJson handler = ParseJSON;

                handler.Invoke(fileName);
            }
            
            if (filetype.Contains("xml"))
            {
                
                ParseXml handler = ParseXML;
                handler.Invoke(fileName);
            }

            return ValueList;

        }

    }
}