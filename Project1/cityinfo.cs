using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Project1
{
    public struct Location//public struct allows for each variable to be represented in its own right, everywhere referenced.
    {
        public double? Latitude { get; init; }
        public double? Longitude { get; init; }

        public Location(double? latitude, double? longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    [Serializable]
    public class CityInfo
    {
        [JsonProperty("id")]
        public int CityID { get; init; }

        [JsonProperty("city")]
        public string CityName { get; init; }

        [JsonProperty("city_ascii")]
        public string? CityAscii { get; init; }

        [JsonProperty("population")]
        public int? Population { get; init; }

        [JsonProperty("region")]
        public string? Province { get; init; }

        [JsonProperty("lat")]
        public double? Lat { get; init; }

        [JsonProperty("lng")]
        public double? Lng { get; init; }

        public CityInfo(int cityid, string cityname, string? cityacii,
            int? population, string? province, double? lat, double? lng) {
            
            CityID = cityid;
            CityName = cityname;
            CityAscii = cityacii;
            Population = population;
            Province = province;
            Lat = lat;
            Lng = lng;
        }

        public string? GetProvince()
        {
            return Province;
        }

        public int? GetPopulation()
        {
            return Population;
        }

        public Location? GetLocation()
        {
            return new Location(Lat, Lng);
        }

        public override string ToString()
        {
            return $"{CityName}, {Province}: Population of {Population}";
        }
    }
}