using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project1
{
    [XmlRoot(ElementName = "CanadaCities")]
    public class xmlCities
    {
        [XmlElement(ElementName = "CanadaCity")]
        public List<CityInfo> info { get; set; }

        public xmlCities() { 
            info = new List<CityInfo>();
        }
    }
}
