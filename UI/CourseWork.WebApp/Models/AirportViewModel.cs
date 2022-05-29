using System.Collections.Generic;

namespace CourseWork.WebApp.Models
{
    public class AirportViewModel
    {
        public string Name { get; set; }

        public int CountAirplane { get; set; }

        public Stack<AirplaneViewModel> Airplanes { get; set; } = new Stack<AirplaneViewModel>();
    }
}
