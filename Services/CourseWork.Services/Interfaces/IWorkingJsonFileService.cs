using CourseWork.Structures.Structure;

namespace CourseWork.Services.Interfaces
{
    public interface IWorkingJsonFileService
    {
        void Save(AirCompany company, string file_path);

        AirCompany Download(string file_path);
    }
}
