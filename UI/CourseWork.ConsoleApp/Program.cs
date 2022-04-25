using CourseWork_Algorithms_Data_Structures;
using CourseWork_Algorithms_Data_Structures.Services;
using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CourseWork.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service_collection = new ServiceCollection();
            service_collection.AddSingleton<IWorkingFileService, XmlService>();

            //Получение сервисов
            var provider = service_collection.BuildServiceProvider();
            var service = provider.GetRequiredService<IWorkingFileService>();

            //Создание объекта - Репозиторий, главный класс, для работы со структурой
            Repository rep = new Repository(service);

            var _object = new ObjMainJson()
            {
                Name = rep.GetMainStructure().Name,
                Airports = new List<ObjSecondJson>()
            };

            foreach (var _airport in rep.GetMainStructure())
            {
                var airport = new ObjSecondJson()
                {
                    Name = _airport.Name,
                    Airplanes = new List<Airplane>()
                };
                foreach (var _airplane in _airport)
                {
                    var airplane = new Airplane(_airplane.Brand, _airplane.YearofManufacture);
                    airport.Airplanes.Add(airplane);
                }
                _object.Airports.Add(airport);
            }

            string str = JsonConvert.SerializeObject(_object);
            Console.WriteLine(str);
            //AirCompany deserializedProduct = JsonConvert.DeserializeObject<AirCompany>(str);
            //App.Run(rep);
        }
    }
}
