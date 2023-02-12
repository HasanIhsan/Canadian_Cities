using CsQuery.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace Project1
{
    
    using Dictionary_T = Dictionary<string, List<CityInfo>>;

    public class Statistics
    {
        public Dictionary_T CityCatelogue { get; init; }

        public Statistics(string fileName, string fileType)
        {
            DataModeler dm = new DataModeler();
            CityCatelogue = dm.ParseFile(fileName, fileType);
            CityInfo? famous = GetCity("Victoria", "British Columbia");

            if(famous != null) { 
                Console.WriteLine($"Population of {famous.Province} is {DisplayProvincePopulation(famous.Province)}\nPopulation of {famous.CityName} is {famous.Population}");
            }
        }

        //City Methods
        public List<CityInfo>? DisplayCityInformation(string cityName)
        {
            if(!CityCatelogue.ContainsKey(cityName))
                throw new ArgumentOutOfRangeException(nameof(cityName), $"{cityName} is not a city from the collection.");
            return CityCatelogue[cityName];
        }

        public CityInfo? DisplayLargestPopulationCity(string province)
        {
            return SortCities(new OrderByPopulation(), CityCatelogue).Last(city => city.Province == province);
        }

        public CityInfo? DisplaySmallestPopulationCity(string province)
        {
            return SortCities(new OrderByPopulation(), CityCatelogue).First(city => city.Province == province);
        }

        public CityInfo? CompareCitiesPopulation(CityInfo city1, CityInfo city2)
        {
            return city1.Population > city2.Population ? city1 : city2;
        }

        public void ShowCityOnMap(string cityName, string prov)
        {
            CityInfo? city = GetCity(cityName, prov);

            if(city == null)
                throw new ArgumentOutOfRangeException(nameof(city), $"Province doesn't have a city named {cityName}");
                
            Process.Start(new ProcessStartInfo(($"https://www.latlong.net/c/?lat={city.Lat}&long={city.Lng}")) { UseShellExecute = true });
        }
        //=acos(sin(lat1)*sin(lat2)+cos(lat1)*cos(lat2)*cos(lon2-lon1))*6371
        public int? CalculateDistanceBetweenCities(CityInfo city1, CityInfo city2)
        {
            string key = "AIzaSyBuWX6ELFtlNhqHk5EcKrmXWBdrmHeNm5A";
            string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?destinations={city2.CityName.Replace(" ", "%20")}%2C{city2.Province}&origins={city1.CityName.Replace(" ", "%20")}%2C{city1.Province}&key={key}";
            int? distance = null;
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(url).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;
                JToken? token = JObject.Parse(responseBody).SelectToken(".rows[0].elements[0].distance.value");
                if(token != null)
                    distance = token.Value<int?>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return distance;
        }

        //public double CalculateDistanceToCapital(CityInfo city

        //Province Methods
        public int DisplayProvincePopulation(string province)
        {
            int i = 0;
            //CityCatelogue.Sum((kvp) => kvp.Value.Sum((city) => i += city.Province == province ? city.Population : 0));

            //foreach (CityInfo info in kvp.Value)
            //        i += info.Province == province ? info.Population : 0;
            //);
            foreach (KeyValuePair<string, List<CityInfo>> kvp in CityCatelogue)
            {
                foreach (CityInfo city in kvp.Value)
                {
                    i += city.Province == province ? city.Population : 0;
                }
            }
            return i;
        }

        public List<CityInfo> DisplayProvinceCities(string province)
        {
            return CityCatelogue.First().Value;
        }

        public List<string> RandProvinceByPopulation()
        {
            return new List<string>();
        }

        public List<CityInfo> RankProvincesByCities()
        {

            return CityCatelogue.First().Value;
        }

        public CityInfo GetCapital(string province)
        {
            return CityCatelogue.First().Value[0];
        }
        
        //Private helper methods
        private SortedSet<CityInfo> SortCities(IComparer<CityInfo> sorter, Dictionary_T list)
        {
            SortedSet<CityInfo> ss = new SortedSet<CityInfo>(sorter);

            foreach(KeyValuePair<string, List<CityInfo>> city in list)
            { 
                foreach(CityInfo cityInfo in city.Value) 
                {
                    ss.Add(cityInfo);
                }
            }

            return ss;
        }

        private CityInfo? GetCity(string cityName, string province)
        {
            if (!CityCatelogue.ContainsKey(cityName))
                throw new ArgumentOutOfRangeException(cityName, $"City {cityName} not found in catelogue.");

            CityInfo? city = CityCatelogue[cityName].Find(c => c.Province == province);
            
            return city;
        }
    }
}