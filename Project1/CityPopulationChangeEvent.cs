using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class CityPopulationChangeEvent : EventArgs
    {
        public int CurrentPop { get; set; }
        public int NewPop { get; set; }

        public CityPopulationChangeEvent(int currentPop, int newPop)
        {
            CurrentPop = currentPop;
            NewPop = newPop;
        }
    }
}
