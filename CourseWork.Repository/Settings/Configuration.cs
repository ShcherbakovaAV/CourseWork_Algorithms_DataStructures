using Microsoft.Extensions.Configuration;


namespace CourseWork_Algorithms_Data_Structures
{
    /// <summary>
    /// Класс, для рабоыт с настройками
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Путь файла, по которому загружаем структуру
        /// </summary>
        public string FileInput { get; set; }

        /// <summary>
        /// Путь файла, из которого загружаем структуру
        /// </summary>
        public string FileOutput { get; set; }

    }
}
