﻿using CourseWork.Repository;
using CourseWork.Structures.Structure;
using System;

namespace CourseWork.ConsoleApp
{
    public class App
    {
        public static void Run(Storage repository)
        {
            Console.WriteLine("Консольный интерфейс для работы со структурой");
            while (true)
            {
                Console.WriteLine("Выбирите действия:");
                Console.WriteLine("0 - Выход из программы");
                Console.WriteLine("1 - Создать авиокомпанию");
                Console.WriteLine("2 - Добавление аэропорта");
                Console.WriteLine("3 - Добавление самолета в аэропорт");
                Console.WriteLine("4 - Удаление аэропорта");
                Console.WriteLine("5 - Удаление самолета");
                Console.WriteLine("6 - Поиск аэропорта");
                Console.WriteLine("7 - Поиск самолета");
                Console.WriteLine("8 - Сохранение структуру авиокомпании в XML файл");
                Console.WriteLine("9 - Сохранение структуру авиокомпании в JSON-файл");
                Console.WriteLine("10 - Загрузка структуру авиокомпании из XML файла");
                Console.WriteLine("11 - Загрузка структуру авиокомпании из JSON файла");
                Console.WriteLine("12 - Очистить структуру");
                Console.WriteLine("13 - Просмотр структуры авиокомпании");

                Console.Write("Выбор: ");
                int choice = InputInteger();
                Console.WriteLine();

                if (choice == 1)
                {
                    Console.Write("Введите название аэрокомпании: ");
                    string name_aircompany = Console.ReadLine();
                    repository.CreateAircompany(name_aircompany);
                    Console.WriteLine("Аэрокомпания успешно создана!");
                }
                else if (choice == 2)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите название аэропорта: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.AddAirport(name_airport);
                        Console.WriteLine("Аэропорт успешно добавлен!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 3)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите бренд самолета: ");
                    string brand_airplane = Console.ReadLine();
                    Console.Write("Введите год производства самолета: ");
                    int year_airplane = InputInteger();
                    Console.Write("Введите название аэропорта самолета: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.AddAirplane(brand_airplane, year_airplane, name_airport);
                        Console.WriteLine($"Самолет успешно добавлен в аэропорт: {name_airport}!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 4)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    try
                    {
                        repository.DeleteAirport();
                        Console.WriteLine("Аэропорт успешно удален!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 5)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите название аэропорта самолета: ");
                    string name_airport = Console.ReadLine();
                    try
                    {
                        repository.DeleteAirplane(name_airport);
                        Console.WriteLine($"Самолет в {name_airport} успешно удален!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 6)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите название аэропорта: ");
                    string name_airport = Console.ReadLine();
                    Airport airport = null;
                    try
                    {
                        airport = repository.ContainsAirport(name_airport);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    if (airport is null)
                        Console.WriteLine($"Аэропорт {name_airport} не найден");
                    else
                        Console.WriteLine($"Аэропорт {airport.Name} успешно найден. Кол-во самолетов в нем: {airport.Count}!");
                }
                else if (choice == 7)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите бренд самолета: ");
                    string brand_airplane = Console.ReadLine();
                    Console.Write("Введите год производства самолета: ");
                    int year_airplane = InputInteger();
                    try
                    {
                        var airplane = repository.ContainsAirplane(brand_airplane, year_airplane, out string name_airport);

                        if (airplane is null)
                            Console.WriteLine("Самолет не найден!");
                        else
                            Console.WriteLine($"Самолет: {airplane.Brand}-{airplane.YearofManufacture} найден в аэропорту: {name_airport}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (choice == 8)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите название xml файла(Enter - путь к файлу по умолчанию): ");
                    string file_path = Console.ReadLine();
                    if (string.IsNullOrEmpty(file_path))
                        repository.SaveToXml();
                    else
                    {
                        try
                        {
                            repository.SaveToXml(file_path);
                            Console.WriteLine("Сохранение произведено успешно!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    
                }
                else if (choice == 9)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    Console.Write("Введите название json файла(Enter - путь к файлу по умолчанию): ");
                    string file_path = Console.ReadLine();
                    if (string.IsNullOrEmpty(file_path))
                        repository.SaveToJson();
                    else
                    {
                        try
                        {
                            repository.SaveToJson(file_path);
                            Console.WriteLine("Сохранение произведено успешно!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                    
                }
                else if (choice == 10)
                {
                    Console.Write("Введите название xml-файла(Enter - путь к файлу по умолчанию): ");
                    string file_path = Console.ReadLine();
                    if (string.IsNullOrEmpty(file_path))
                        repository.DownloadFromXml();
                    else
                    {
                        try
                        {
                            repository.DownloadFromXml(file_path);
                            Console.WriteLine("Загрузка произведена успешно!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Указанного файла не существует");
                        }
                    }
                }
                else if (choice == 11)
                {
                    Console.Write("Введите название json-файла(Enter - путь к файлу по умолчанию): ");
                    string file_path = Console.ReadLine();
                    if (string.IsNullOrEmpty(file_path))
                        repository.DownloadFromJson();
                    else
                    {
                        try
                        {
                            repository.DownloadFromJson(file_path);
                            Console.WriteLine("Загрузка произведена успешно!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Указанного файла не существует");
                        }
                    }
                    
                }
                else if (choice == 12)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }
                    try
                    {
                        repository.ClearMainStructure();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    Console.WriteLine("Структура успешно очищена!");
                }
                else if (choice == 13)
                {
                    if (!repository.IsExistMainStructure)
                    {
                        Console.WriteLine("Авиокомпания не создана!");
                        continue;
                    }

                    AirCompany company = repository.GetMainStructure();

                    if (company.IsEmpty)
                    {
                        Console.WriteLine("Структура пустая!");
                        continue;
                    }

                    Console.WriteLine($"Аэрокомпания: {company.Name}. Всего аэропортов: {company.CountAirport}. Всего самолетов: {company.CountAirplane}");
                    foreach (var airport in company)
                    {
                        Console.WriteLine($" Аэропорт {airport.Name}. Кол-во самолетов: {airport.Count}: ");
                        int number = 1;
                        Console.WriteLine($"   Самолеты:");
                        foreach (var airplane in airport)
                        {
                            Console.WriteLine($"     №{number} Бренд:{airplane.Brand} - Год выпуска:{airplane.YearofManufacture} ");
                            number++;
                        }
                        Console.WriteLine();
                    }
                }
                else if (choice == 0)
                    break;
            }

            Console.WriteLine("Программа завершила свою работу!");
        }
        public static int InputInteger()
        {
            string input; bool stop = false;
            int integer = -1;
            while (!stop)
            {
                try
                {
                    input = Console.ReadLine();
                    integer = int.Parse(input);
                    stop = true;
                }
                catch (Exception)
                {
                    Console.Write("Введите целое число: ");
                }
            }
            return integer;
        }

    }
}
