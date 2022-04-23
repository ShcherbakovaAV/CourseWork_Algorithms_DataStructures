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
            XDocument xdoc = new XDocument();

            XElement company_ = new XElement("company");

            XAttribute companyNameAttr = new XAttribute("name", company.Name);

            company_.Add(companyNameAttr);

            foreach (var airport in company)
            {
                XElement airport_ = new XElement("airport");

                XAttribute airportNameAttr = new XAttribute("name", airport.Name);

                airport_.Add(airportNameAttr);

                foreach (var airplane in airport)
                {
                    XElement airplane_ = new XElement("airplane");
                    XElement airplane_brand = new XElement("brand", airplane.Brand);
                    XElement airplane_year = new XElement("year", airplane.YearofManufacture);
                    airplane_.Add(airplane_brand);
                    airplane_.Add(airplane_year);
                    airport_.Add(airplane_);
                }

                company_.Add(airport_);
            }

            xdoc.Add(company_);

            //сохраняем документ
            if (file_path is null)
                xdoc.Save(_filePathOutput);
            else
                xdoc.Save(file_path);
        }

        /// <summary>
        /// Выгрузка структуры
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns></returns>
        public AirCompany DownloadFromXml(string file_path = null)
        {
            XmlDocument xDoc = new XmlDocument();

            if (file_path is null)
                xDoc.Load(_filePathInput);
            else
                xDoc.Load(file_path);

            XmlElement xRoot = xDoc.DocumentElement;

            AirCompany company = new AirCompany(xRoot.GetAttribute("name").ToString());

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    string name_airport = xnode.Attributes.GetNamedItem("name").Value;
                    Airport airport = new Airport(name_airport);
                    company.PushAirport(airport);

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        string airplane_name = null;
                        string airplane_year = null;

                        foreach (XmlNode ch in childnode.ChildNodes)
                        {
                            if (ch.Name == "brand")
                            {
                                airplane_name = ch.InnerText;
                            }

                            if (ch.Name == "year")
                            {
                                airplane_year = ch.InnerText;
                            }
                        }
                        
                        Airplane airplane = new Airplane(airplane_name, Convert.ToInt32(airplane_year));

                        airport.Push(airplane);
                    }
                }
            }

            return company;
        }
    }
}
