using CourseWork.Structures.Structure;
using CourseWork.WebApp.Models;

namespace CourseWork.WebApp.Mapping
{
    public static class AircompanyMapper
    {
        public static AircompanyViewModel? ToView(this AirCompany? aircompany)
        {
            if (aircompany == null)
                return null;

            var viewModel = new AircompanyViewModel 
            { 
                Name = aircompany.Name,
                CountAirpotrs = aircompany.CountAirport,
                CountAirpanes = aircompany.CountAirplane
            };

            foreach (var airport in aircompany)
            {
                var airport_view = new AirportViewModel
                {
                    Name = airport.Name,
                    CountAirplane = airport.Count
                };
                foreach (var airplane in airport)
                {
                    var airplane_view = new AirplaneViewModel
                    {
                        Brand = airplane.Brand,
                        YearofManufacture = airplane.YearofManufacture,
                    };
                    airport_view.Airplanes.Push(airplane_view);
                }
                viewModel.Airports.Enqueue(airport_view);                
            }

            return viewModel;
        }
    }
}
