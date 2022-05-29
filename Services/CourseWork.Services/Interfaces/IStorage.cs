using CourseWork.Structures.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork.Services.Interfaces
{
    public interface IStorage
    {
        AirCompany GetMainStructure();

        void CreateAircompany(string name_aircompany);

        void AddAirport(string name_airport);

        void AddAirplane(string brand, int year, string name_airport);

        bool DeleteAirport();

        bool DeleteAirplane(string name_airport);

        Airport ContainsAirport(string name_airport);

        Airplane ContainsAirplane(string brand, int year, out string name_airport);

        void ClearMainStructure();

        void SaveToXml(string file_path = null);

        void DownloadFromXml(string file_path = null);

        void SaveToJson(string file_path = null);

        void DownloadFromJson(string file_path = null);
    }
}
