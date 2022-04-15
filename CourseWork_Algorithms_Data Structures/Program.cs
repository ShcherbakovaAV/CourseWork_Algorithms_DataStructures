using System;

namespace CourseWork_Algorithms_Data_Structures
{
    public class Program
    {
        static void Main(string[] args)
        {
            AirCompany company = new AirCompany("Победа");

            company.PushAirport("Казань");
            company.PushAirport("Москва");
            company.PushAirport("Екатеринбург");

            company.PushAirplane("ТУ-204", 2005, "Казань");
            company.PushAirplane("МС-21", 2005, "Казань");
            company.PushAirplane("ТУ-141", 2005, "Москва");

            foreach (var airport in company)
            {
                Console.Write($"{airport.Name}: ");

                foreach (var airplane in airport)
                {
                    Console.Write($"{airplane.Brand}-{airplane.YearofManufacture}; ");
                }

                Console.WriteLine();
            }

            Repository rep = new Repository();

            AirCompany company2 = rep.DownloadFromXml("company.xml");

            Console.WriteLine();
            Console.WriteLine();

            foreach (var airport in company2)
            {
                Console.Write($"{airport.Name}: ");

                foreach (var airplane in airport)
                {
                    Console.Write($"{airplane.Brand}-{airplane.YearofManufacture}; ");
                }

                Console.WriteLine();
            }


        }
    }
}
