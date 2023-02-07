namespace Project1
{
    public class cityinfo
    {
        public int CityID { get; set; }
        public string city{ get; set; }
        public string CityAscii { get; set; }
        public int Population { get; set; }
        public string Province { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public cityinfo(int cityid, string cityname, string cityacii, int population, string province, double lat, double lng) { 
            this.CityID = cityid;
            this.city= cityname;
            this.CityAscii= cityacii;
            this.Population = population;
            this.Province = province;
            this.Latitude = lat;
            this.Longitude = lng;
        }


        public string GetProvince()
        {
            return Province;
        }

        public int GetPopulation()
        {
            return Population;
        }

        public double GetLocation()
        {
            return Latitude + Longitude;
        }

 

    }
}