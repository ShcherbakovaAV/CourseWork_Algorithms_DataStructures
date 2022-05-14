using CourseWork.Structures.Structure;

namespace CourseWork.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с файлами
    /// </summary>
    public interface IWorkingXmlFileService
    {
        void Save(AirCompany company, string file_path);

        AirCompany Download(string file_path);
    }
}
