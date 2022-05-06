using CourseWork.Services.Interfaces;
using CourseWork.Services.JsonModels;
using CourseWork_Algorithms_Data_Structures;
using CourseWork_Algorithms_Data_Structures.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CourseWork.Services
{
    public class JsonService : IWorkingJsonFileService
    {
        public AirCompany Download(string file_path)
        {
            var main_object = JsonConvert.DeserializeObject<ObjMainJson>(File.ReadAllText(file_path));

            AirCompany company = new AirCompany(main_object.Name);

            foreach (var _airport in main_object.Airports)
            {
                Airport airport = new Airport(_airport.Name);

                company.PushAirport(airport);

                foreach (var _airplane in _airport.Airplanes)
                {
                    string airplane_brand = _airplane.Brand;
                    int airplane_year = _airplane.YearofManufacture;

                    Airplane airplane = new Airplane(airplane_brand, airplane_year);

                    airport.Push(airplane);
                }
            }

            return company;

        }

        public void Save(AirCompany company, string file_path)
        {
            var main_object = new ObjMainJson()
            {
                Name = company.Name,
                Airports = new List<ObjSecondJson>()
            };

            foreach (var _airport in company)
            {
                var airport = new ObjSecondJson()
                {
                    Name = _airport.Name,
                    Airplanes = new List<Airplane>()
                };

                foreach (var _airplane in _airport)
                {
                    var airplane = new Airplane(_airplane.Brand, _airplane.YearofManufacture);
                    airport.Airplanes.Add(airplane);
                }

                main_object.Airports.Add(airport);
            }

            string result = JsonConvert.SerializeObject(main_object);

            StreamWriter file = File.CreateText(file_path);
            file.WriteLine(result);
            file.Close();
        }
    }
}
