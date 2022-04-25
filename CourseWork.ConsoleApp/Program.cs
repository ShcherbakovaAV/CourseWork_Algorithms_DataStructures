using CourseWork_Algorithms_Data_Structures;
using CourseWork_Algorithms_Data_Structures.Services;
using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

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

            
            App.Run(rep);
        }
    }
}
