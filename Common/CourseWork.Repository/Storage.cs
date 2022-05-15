using CourseWork.Repository.Settings;
using CourseWork.Services.Interfaces;
using CourseWork.Structures.Structure;
using Microsoft.Extensions.Configuration;
using System;

namespace CourseWork.Repository
{
    /// <summary>
    /// Класс, предназначенный для работы со структурой
    /// </summary>
    public class Storage
    {
        private Configuration _configuration;

        private readonly IWorkingXmlFileService _xmlService;
        private readonly IWorkingJsonFileService _jsonService;

        private AirCompany _mainStructure;

        /// <summary>
        /// Получение главной структуры
        /// </summary>
        /// <returns></returns>
        public AirCompany GetMainStructure() => _mainStructure;

        public Storage(IWorkingXmlFileService xmlService, IWorkingJsonFileService jsonService)
        {
            _xmlService = xmlService;
            _jsonService = jsonService;

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var section = configuration.GetSection("Configuration");
            _configuration = section.Get<Configuration>();
        }

        public void CreateAircompany(string name_aircompany)
        {
            _mainStructure = new AirCompany(name_aircompany);
        }

        public void AddAirport(string name_airport)
        {
            if (name_airport is null)
                throw new ArgumentNullException(nameof(name_airport));

            _mainStructure.PushAirport(name_airport);
        }

        public void AddAirplane(string brand, int year, string name_airport)
        {
            if (brand is null || year < 1970 && year > 2022 || name_airport is null)
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
            if (name_airport is null)
                throw new ArgumentNullException(nameof(name_airport));

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

        public Airplane ContainsAirplane(string brand, int year, out string name_airport)
        {
            return _mainStructure.Contains_Airplane(brand, year, out name_airport);
        }

        public void ClearMainStructure()
        {
            _mainStructure.Clear();
        }

        /// <summary>
        /// Сохранение структуры в xml
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="company"></param>
        public void SaveToXml(string file_path = null)
        {
            if (file_path is null)
                _xmlService.Save(_mainStructure, _configuration.Xml.FileOutput);
            else
                _xmlService.Save(_mainStructure, file_path);
        }

        /// <summary>
        /// Выгрузка структуры из xml
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public void DownloadFromXml(string file_path = null)
        {
            if (file_path is null)
                _mainStructure = _xmlService.Download(_configuration.Xml.FileInput);
            else
                _mainStructure = _xmlService.Download(file_path);

            if (_mainStructure is null)
                throw new NullReferenceException("Компания не создана");
        }

        public void SaveToJson(string file_path = null)
        {
            if (file_path is null)
                _jsonService.Save(_mainStructure, _configuration.Json.FileOutput);
            else
                _jsonService.Save(_mainStructure, file_path);
        }

        public void DownloadFromJson(string file_path = null)
        {
            if (file_path is null)
                _mainStructure = _jsonService.Download(_configuration.Json.FileOutput);
            else
                _mainStructure = _jsonService.Download(file_path);

            if (_mainStructure is null)
                throw new NullReferenceException("Компания не создана");
        }

    }
}
