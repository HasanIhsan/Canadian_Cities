using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Xml.Linq;

namespace Project1
{
    public class DataModeler
    {

         
        List<Dictionary<string, string>> ValueList = new();
     //  public List<cityinfo> cit = new(); //list of cities

        

        public delegate void ParseJson(string file);
        public delegate void ParseXml(string file);

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
                    addcount= 0;
                }
            }

             
            
        }

        public List<Dictionary<string, string>> ParseFile(string fileName, string filetype)
        {

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