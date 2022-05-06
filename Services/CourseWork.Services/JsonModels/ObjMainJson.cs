using CourseWork_Algorithms_Data_Structures;
using System.Collections.Generic;

namespace CourseWork.Services.JsonModels
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
