using CourseWork_Algorithms_Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.ConsoleApp
{
    public class ObjMainJson
    {
        public string Name { get; set; }

        public List<ObjSecondJson> Airports { get; set; }

    }

    public class ObjSecondJson
    {
        public string Name { get; set; }

        public List<Airplane> Airplanes { get; set; }
    }
}
