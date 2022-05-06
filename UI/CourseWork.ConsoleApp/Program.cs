using CourseWork.Services;
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
            //Repository rep = new Repository(service);

            Storage repo = new Storage(service);

            JsonService _service = new JsonService();

            var structure = _service.Download("company.json");

            structure.PushAirport("Южно-Сахалинск");
            structure.PushAirplane("СУ-24", 1999, "Южно-Сахалинск");
            _service.Save(structure, "company_new.json");
            //AirCompany deserializedProduct = JsonConvert.DeserializeObject<AirCompany>(str);
            //App.Run(rep);
        }
    }
}
