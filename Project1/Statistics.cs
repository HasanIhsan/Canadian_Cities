using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Statistics
    {
        //dictionary generic type?
         //Dictionary<T,T>


        //filetype = JSON, XML, CSV
        public Statistics(string filename, string filetype) {

            string fullfilename = filename + "." + filetype;

            DataModeler modeler = new();


            //say if the user clicks on a file that is a json
            if(filetype.Contains(".json"))
            {
                //DataModeler.ParseJson parsejson = modeler.ParseJSON;

                //call the parse method for json
               // modeler.ParseFile(fullfilename, parsejson);

            }

            //put the data from parse to dictionary?




        }
    }
}
