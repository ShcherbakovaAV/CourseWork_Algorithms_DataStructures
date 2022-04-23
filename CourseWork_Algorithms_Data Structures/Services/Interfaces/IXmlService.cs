using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures.Services.Interfaces
{
    public interface IXmlService
    {
        void SaveToXml(AirCompany company, string file_path);

        AirCompany DownloadFromXml(string file_path);
    }
}
