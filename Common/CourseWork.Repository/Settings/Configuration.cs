using CourseWork.Repository.Settings;

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
