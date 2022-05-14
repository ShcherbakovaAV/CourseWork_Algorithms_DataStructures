using CourseWork.Repository;
using CourseWork.Services;
using CourseWork.Services.Interfaces;
using CourseWork_Algorithms_Data_Structures;
//using CourseWork_Algorithms_Data_Structures.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CourseWork.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Коллекция сервисов
            var service_collection = new ServiceCollection();

            service_collection.AddSingleton<IWorkingXmlFileService, XmlService>();
            service_collection.AddSingleton<IWorkingJsonFileService, JsonService>();

            //Получение сервисов
            var provider = service_collection.BuildServiceProvider();
            var xml_service = provider.GetRequiredService<IWorkingXmlFileService>();
            var json_service = provider.GetRequiredService<IWorkingJsonFileService>();

            //Создание объекта - Репозиторий, главный класс, для работы со структурой
            Storage storage = new Storage(xml_service, json_service);

            //Запуск приложения
            App.Run(storage);
        }
    }
}
