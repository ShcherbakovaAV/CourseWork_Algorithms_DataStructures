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
            //Регистрация сервисов
            var service_collection = new ServiceCollection();
            service_collection.AddSingleton<IWorkingFileService, XmlService>();

            //Получение сервисов
            var provider = service_collection.BuildServiceProvider();
            var service = provider.GetRequiredService<IWorkingFileService>();

            //Создание объекта - Репозиторий, главный класс, для работы со структурой
            Repository rep = new Repository(service);

            ConsoleApp.Run(rep);
        }
    }
}
