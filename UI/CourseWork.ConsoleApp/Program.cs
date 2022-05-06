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
    public class Program
    {
        static void Main(string[] args)
        {
            //Коллекция сервисов
            var service_collection = new ServiceCollection();

            Console.WriteLine("Выберите тип файлов, с которыми будете работать: 1 - xml; 2 - json");
            Console.Write("Выбор: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
                service_collection.AddSingleton<IWorkingXmlFileService, XmlService>();
            else
                service_collection.AddSingleton<IWorkingXmlFileService, JsonService>();

            //Получение сервисов
            var provider = service_collection.BuildServiceProvider();
            var service = provider.GetRequiredService<IWorkingXmlFileService>();

            //Создание объекта - Репозиторий, главный класс, для работы со структурой
            Storage storage = new Storage(service);

            //Запуск приложения
            App.Run(storage);
        }
    }
}
