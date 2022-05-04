using CourseWork.Repository.Settings;
using Microsoft.Extensions.Configuration;


namespace CourseWork_Algorithms_Data_Structures
{
    /// <summary>
    /// Класс, для рабоыт с настройками
    /// </summary>
    public class Configuration
    {
        public ConfigurationXml Xml { get; set; }

        public ConfigurationJson Json { get; set; }

    }
}
