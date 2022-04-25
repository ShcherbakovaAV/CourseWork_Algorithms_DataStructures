using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с файлами
    /// </summary>
    public interface IWorkingFileService
    {
        void Save(AirCompany company, string file_path);

        AirCompany Download(string file_path);
    }
}
