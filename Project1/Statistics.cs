using System.Diagnostics;

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
            Console.WriteLine(DisplayLargestPopulationCity("Alberta"));
            Console.WriteLine(DisplayLargestPopulationCity("Ontario"));
            ShowCityOnMap("Toronto", "Ontario");
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
            return SortCities(new OrderByPopulation()).Last<CityInfo>(city => city.Province == province);
        }

        public CityInfo? DisplaySmallestPopulationCity(string province)
        {
            return SortCities(new OrderByPopulation()).First<CityInfo>(city => city.Province == province);
        }

        public CityInfo CompareCitiesPopulation(CityInfo city, CityInfo info)
        {
            return city.Population > info.Population ? city : info;
        }

        public void ShowCityOnMap(string cityName, string prov)
        {
            if(!CityCatelogue.ContainsKey(cityName))
                throw new ArgumentOutOfRangeException(cityName, $"City {cityName} not found in catelogue.");

            CityInfo? city = CityCatelogue[cityName].Find(c => c.Province == prov);

            if (city == null) throw new ArgumentOutOfRangeException(prov, $"Province {prov} doesn't have a city named {cityName}.");

            Process.Start(new ProcessStartInfo(($"https://www.latlong.net/c/?lat={city.Lat}&long={city.Lng}")) { UseShellExecute = true });
        }
        //Private helper methods
        private SortedSet<CityInfo> SortCities(IComparer<CityInfo> sorter)
        {
            SortedSet<CityInfo> ss = new SortedSet<CityInfo>(sorter);
            foreach(KeyValuePair<string, List<CityInfo>> city in CityCatelogue)
            { 
                foreach(CityInfo cityInfo in city.Value) 
                {
                    ss.Add(cityInfo);
                }
            }

            return ss;
        }
    }
}