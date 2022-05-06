using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Xml;
using System.Xml.Linq;

namespace CourseWork_Algorithms_Data_Structures
{
    /// <summary>
    /// Класс, предназначенный для работы со структурой
    /// </summary>
    public class Storage
    {
        private readonly string _filePathInput;

        private readonly string _filePathOutput;

        private readonly IWorkingFileService _xmlService;

        private AirCompany _mainStructure;

        /// <summary>
        /// Получение главной структуры
        /// </summary>
        /// <returns></returns>
        public AirCompany GetMainStructure() => _mainStructure;

        public Storage(IWorkingFileService xmlService)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var section = configuration.GetSection("Configuration");
            var settings = section.Get<Configuration>();

            _filePathInput = settings.Xml.FileInput;
            _filePathOutput = settings.Xml.FileOutput;
            _xmlService = xmlService;

            this.DownloadFromXml();
        }

        public void AddAirport(string name_airport)
        {
            if (name_airport is null)
                throw new ArgumentNullException(nameof(name_airport));

            _mainStructure.PushAirport(name_airport);
        }

        public void AddAirplane(string brand, int year, string name_airport)
        {
            if (brand is null || (year < 1970 &&  year > 2022) || name_airport is null)
                throw new ArgumentNullException();

            _mainStructure.PushAirplane(brand, year, name_airport);
        }

        public bool DeleteAirport()
        {
            Airport airport = _mainStructure.PopAirport();
            if (airport is null)
                return false;
            else
                return true;
        }
        
        public bool DeleteAirplane(string name_airport)
        {
            Airplane airplane = _mainStructure.PopAirplane(name_airport);

            if (airplane is null)
                return false;
            else
                return true;
        }

        public Airport ContainsAirport(string name_airport)
        {
            return _mainStructure.Contains_Airport(name_airport);
        }

        public Airplane ContainsAirplane(string brand, int year)
        {
            return _mainStructure.Contains_Airplane(brand, year);
        }

        /// <summary>
        /// Сохранение структуры
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="company"></param>
        public void SaveToXml(AirCompany company, string file_path = null)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            if (file_path is null)
                _xmlService.Save(company, _filePathOutput);
            else
                _xmlService.Save(company, file_path);
        }

        /// <summary>
        /// Выгрузка структуры
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        private void DownloadFromXml(string file_path = null)
        {
            AirCompany company = null;

            if (file_path is null)
                company = _xmlService.Download(_filePathInput);
            else
                company = _xmlService.Download(file_path);

            if (company is null)
                throw new NullReferenceException("Компания не создана");

            this._mainStructure = company;
        }

    }
}
