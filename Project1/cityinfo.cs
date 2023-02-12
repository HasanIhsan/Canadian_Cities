﻿using HtmlParserSharp.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

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

    [XmlRoot(ElementName = "CanadaCities")]
    public class AllCities
    {
        [XmlElement(ElementName = "CanadaCity")]
        public List<CityInfo> Cities_ { get; set; }

        public AllCities()
        {
            Cities_ = new List<CityInfo>();
        }
    }

    [Serializable]
    [XmlRoot(ElementName = "CanadaCity")]
    public class CityInfo
    {
        [JsonProperty("id")]
        [XmlElement(ElementName ="id")]
        public int CityID { get; set; }

        [JsonProperty("city")]
        [XmlElement(ElementName = "city")]
        public string CityName { get; set; }

        [JsonProperty("city_ascii")]
        [XmlElement(ElementName = "city_ascii")]
        public string? CityAscii { get; set; }

        [JsonProperty("population")]
        [XmlElement(ElementName = "population")]
        public int Population { get; set; }

        [JsonProperty("region")]
        [XmlElement(ElementName = "region")]
        public string? Province { get; set; }

        [JsonProperty("lat")]
        [XmlElement(ElementName = "lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        [XmlElement(ElementName = "lng")]
        public double Lng { get; set; }

        public CityInfo() { }

        public CityInfo(int cityid, string cityname, string? cityacii,
            int population, string? province, double lat, double lng) {
            
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