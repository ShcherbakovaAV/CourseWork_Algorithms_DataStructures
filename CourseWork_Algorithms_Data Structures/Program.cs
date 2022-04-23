using CourseWork_Algorithms_Data_Structures.Services;
using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CourseWork_Algorithms_Data_Structures
{
    public class Program
    {
        static void Main(string[] args)
        {
            var service_collection = new ServiceCollection();

            service_collection.AddSingleton<IWorkingFileService, XmlService>();

            var provider = service_collection.BuildServiceProvider();

            var service = provider.GetRequiredService<IWorkingFileService>();

            Repository rep = new Repository(service);

            AirCompany company2 = rep.DownloadFromXml();

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

            company2.PushAirport("Санкт-Петербург");
            company2.PushAirplane("ИЛ-81", 2010, "Санкт-Петербург");
            company2.PushAirplane("ИЛ-89", 2012, "Санкт-Петербург");

            rep.SaveToXml(company2);
        }
    }
}
