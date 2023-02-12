
namespace Project1
{
    using System.Runtime;
    using Dictionary_T = Dictionary<string, List<CityInfo>>;

    public class Statistics
    {
        public Dictionary_T CityCatelogue { get; init; }

        public Statistics(string fileName, string fileType)
        {
            DataModeler dm = new DataModeler();
            CityCatelogue = dm.ParseFile(fileName, fileType);
        
            
             
        }
        //display cition info 
        //this is very tedious is maybe too much loops?
        public void DisplayCityInformation(string cname)
        {
            //might chnge this sort of works but doest

            int userinput;


            // for dulicate city names
            List<string> differentProvinceSameCityName = new();


            foreach (var pair in CityCatelogue)
            {
                foreach (CityInfo city in pair.Value)
                {
                    if (city.CityName == cname)
                    {
                        differentProvinceSameCityName.Add(city.Province);
                    }
                }
             
                foreach (CityInfo city in pair.Value)
                {
                    if(city.CityName == cname)
                    { 
                        if (differentProvinceSameCityName.Count > 1)
                        {
                            //province2 = cityinfo[i].Province;

                            // differentProvinceSameCityName.Add(cityinfo[i].Province);
                            Console.WriteLine($"there seem to be {differentProvinceSameCityName.Count} cites with the same name which one were you looking for?");

                            //display both cities
                            for (int j = 0; j < differentProvinceSameCityName.Count; j++)
                            {
                                Console.WriteLine($"{j + 1}. {city.CityName} of {differentProvinceSameCityName[j]}");
                            }

                            //will fail if there user enters values that are not in the array say there are
                            //2 duplicates but user enter 3 (will throw(crash) an exception stoping the program)
                            userinput = Int32.Parse(Console.ReadLine());
                             
                            //this is something
                            
                                //cityinfo.city is the name the user asks for (cname)
                                //and the province (which at this point there are more then 1)
                                //is the same as the differentProvinceSameCityName [username -1) -1 cause user would enter 1 and the index would b 0
                                if (city.CityName == cname && city.Province == differentProvinceSameCityName[userinput - 1])
                                {

                                    Console.WriteLine($"CityID: {city.CityID}");
                                    Console.WriteLine($"CityName: {city.CityName} ");
                                    Console.WriteLine($"City_Ascii: {city.CityAscii} ");
                                    Console.WriteLine($"Population: {city.Population} ");
                                    Console.WriteLine($"Province: {city.Province} ");
                                    Console.WriteLine($"Latitude: {city.GetLocation().Latitude}");
                                    Console.WriteLine($"Longitude: {city.GetLocation().Longitude}");
                                }
                             

                        }else
                        {

                            Console.WriteLine($"CityID: {city.CityID}");
                            Console.WriteLine($"CityName: {city.CityName} ");
                            Console.WriteLine($"City_Ascii: {city.CityAscii} ");
                            Console.WriteLine($"Population: {city.Population} ");
                            Console.WriteLine($"Province: {city.Province} ");
                            Console.WriteLine($"Latitude: {city.GetLocation().Latitude}");
                            Console.WriteLine($"Longitude: {city.GetLocation().Longitude}");
                        }
                         

                    }
                }

            }
             
        }



        public void DisplayLargestPopulationCity()
        {
            int largestPopulation = 0;
            string largestPopulationProvince = "";
            string largestPopulationCity = "";
          

            foreach (var pair in CityCatelogue)
            {
               
                foreach (CityInfo city in pair.Value)
                {
                     largestPopulation = city.GetPopulation();
                    if (city.GetPopulation() > largestPopulation)
                    {
                        largestPopulation = city.GetPopulation();
                        largestPopulationProvince = city.Province;
                        largestPopulationCity = city.CityName;
                    }
                }
            }

            Console.WriteLine($"The Province of {largestPopulationProvince} has the largest population of {largestPopulation} in the city of {largestPopulationCity}");
        }
    }
}