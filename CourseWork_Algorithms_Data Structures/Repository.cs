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
    public class Repository
    {
        private readonly string _filePathInput;

        private readonly string _filePathOutput;

        private readonly IWorkingFileService _xmlService;

        private AirCompany _mainStructure;

        public Repository(IWorkingFileService xmlService)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var section = configuration.GetSection("Configuration");
            var settings = section.Get<Configuration>();

            _filePathInput = settings.FileInput;
            _filePathOutput = settings.FileOutput;
            _xmlService = xmlService;

            this.DownloadFromXml();
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
