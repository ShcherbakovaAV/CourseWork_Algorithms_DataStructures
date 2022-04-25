using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CourseWork_Algorithms_Data_Structures.Services
{
    /// <summary>
    /// Сервис, для работы с XML-файлом
    /// </summary>
    public class XmlService : IWorkingFileService
    {
        public AirCompany Download(string file_path)
        {
            XmlDocument xDoc = new XmlDocument();

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

        public void Save(AirCompany company, string file_path)
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
            xdoc.Save(file_path);
        }
    }
}
