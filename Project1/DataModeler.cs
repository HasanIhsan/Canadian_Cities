using Newtonsoft.Json;

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
            string raw;

            CheckFile(fileName, out raw);

            List<CityInfo>? info = JsonConvert.DeserializeObject<List<CityInfo>>(raw);
            
            if(info == null )
                throw new FileLoadException($"File not found, {fileName} is not serializable in expected format.", fileName);

            foreach(CityInfo i in info)
            {
                if(ValueList.ContainsKey(i.CityName))
                {
                    ValueList[i.CityName].Add(i);
                }
                else
                {
                    ValueList.Add(i.CityName, new());
                    ValueList[i.CityName].Add(i);
                }
            }
        }

        private void ParseXML(string fileName)
        {
            
        }

        private void ParseCSV(string fileName)
        {
            string raw;
            
            CheckFile(fileName,out raw);

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
                        ValueList[city.CityName].Add(city);
                    }
                }
            }
        }

        public Dictionary_T ParseFile(string fileName, string type)
        {
           fileName = $"{fileName}.{type}";

            switch(type.ToLower())
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

            return ValueList;
        }

        private void CheckFile(string fileName, out string raw)
        {
            if (File.Exists(fileName))
            {
                raw = File.ReadAllText(fileName).ToString();
            }
            else
                throw new FileNotFoundException($"File named {fileName} not found.", fileName);
        }
    }

}