using System.Collections.Generic;

namespace CourseWork.WebApp.Models
{
    public class AircompanyViewModel
    {
        public string Name { get; set; }

        public int CountAirpotrs { get; set; }

        public int CountAirpanes { get; set; }

        public Queue<AirportViewModel> Airports { get; set; }
    }
}
