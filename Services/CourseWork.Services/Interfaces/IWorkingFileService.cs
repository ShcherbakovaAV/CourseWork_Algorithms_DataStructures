namespace CourseWork_Algorithms_Data_Structures.Services.Interfaces
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
