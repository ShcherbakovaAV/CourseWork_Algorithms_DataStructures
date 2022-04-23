using Microsoft.Extensions.Configuration;
using System;
using System.Xml;
using System.Xml.Linq;

namespace CourseWork_Algorithms_Data_Structures
{
    /// <summary>
    /// Класс, предназначенный для работы с xml
    /// </summary>
    public class Repository
    {
        private readonly string _filePathInput;

        private readonly string _filePathOutput;

        public Repository()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            var section = configuration.GetSection("Configuration");
            var settings = section.Get<Configuration>();

            _filePathInput = settings.FileInput;
            _filePathOutput = settings.FileOutput;

        }

        public Repository(string filePathInput, string filePathOutput)
        {
            _filePathInput = filePathInput;
            _filePathOutput = filePathOutput;
        }

        /// <summary>
        /// Сохранение структуры
        /// </summary>
        /// <param name="file_path"></param>
        /// <param name="company"></param>
        public void SaveToXml(AirCompany company, string file_path = null)
        {
            
        }

        /// <summary>
        /// Выгрузка структуры
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public AirCompany DownloadFromXml(string file_path = null)
        {
            
        }
    }
}
