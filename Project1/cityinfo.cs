namespace Project1
{
    public struct Location//public struct allows for each variable to be represented in its own right, everywhere referenced.
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    [Serializable]
    public class CityInfo
    {
        
        public int CityID { get; init; }
        public string CityName{ get; init; }
        public string CityAscii { get; init; }
        public int Population { get; init; }
        public string Province { get; init; }
        public Location location { get; init; }


        public CityInfo(int cityid, string cityname, string cityacii, int population, string province, double lat, double lng) { 
            CityID = cityid;
            CityName= cityname;
            CityAscii= cityacii;
            Population = population;
            Province = province;
            location = new Location(lat, lng);
        }


        public string GetProvince()
        {
            return Province;
        }

        public int GetPopulation()
        {
            return Population;
        }

        public Location GetLocation()
        {
            return location; //You can call each longitude and latitude this way -> location.latitude;
        }

        public override string ToString()
        {
            return $"{CityName}, {Province}: Population of {Population}";
        }

    }
}