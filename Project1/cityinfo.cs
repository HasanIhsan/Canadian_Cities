using System.Xml.Serialization;

namespace Project1
{
    public struct Location//public struct allows for each variable to be represented in its own right, everywhere referenced.
    {
        [XmlAttribute(AttributeName = "lat")]
        public double Latitude { get; init; }
        [XmlAttribute(AttributeName = "lng")]
        public double Longitude { get; init; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    [Serializable]
    [XmlRoot(ElementName = "CanadaCit")]
    public class CityInfo
    {
 //       

       
        [XmlElement(ElementName = "city")]
        public string CityName { get; init; }
        [XmlElement(ElementName = "city_ascii")]
        public string CityAscii { get; init; }
        [XmlElement(ElementName = "lat")]
        public double Latitude { get; init; }
        [XmlElement(ElementName = "lng")]
        public double Longitude { get; init; }
       
        [XmlElement(ElementName = "region")]
        public string Province { get; init; }
        [XmlElement(ElementName = "population")]
        public int Population { get; init; }
        [XmlElement(ElementName = "id")]
        public int CityID { get; init; }


        public Location location { get; init; }


        public CityInfo(int cityid, string cityname, string cityacii, int population, string province, double lat, double lng)
        {
            CityID = cityid;
            CityName = cityname;
            CityAscii = cityacii;
            Population = population;
            Province = province;
            location = new Location(lat, lng);
        }

        public CityInfo()
        {

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