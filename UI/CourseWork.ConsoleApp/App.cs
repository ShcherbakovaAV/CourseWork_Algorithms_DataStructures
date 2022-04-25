using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class App
    {
        public static void Run(Repository repository)
        {
            Console.WriteLine("Консольный интерфейс для работы со структурой");
            Console.WriteLine("Выбирите действия:");
            Console.WriteLine("0 - Выход из программы");
            Console.WriteLine("1 - Просмот структуры");
            Console.WriteLine("2 - Добавление аэропорта");
            Console.WriteLine("3 - Добавление самолета в аэропорт");
            Console.WriteLine("4 - Удаление аэропорта");

            Console.Write("Выбор: ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                AirCompany company = repository.GetMainStructure();

                foreach (var airport in company)
                {
                    Console.WriteLine($"Аэропорт {airport.Name}: ");
                    int number = 1;
                    Console.WriteLine($"  Самолеты:");
                    foreach (var airplane in airport)
                    { 
                        Console.WriteLine($"    №{number} Бренд:{airplane.Brand} - Год выпуска:{airplane.YearofManufacture} ");
                        number++;
                    }
                    Console.WriteLine();
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Введите название аэропорта");
            }
        }
    }
}
