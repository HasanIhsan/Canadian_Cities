
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
        }
    }
}