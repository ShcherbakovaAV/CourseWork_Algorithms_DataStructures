namespace CourseWork.Repository.Settings
{
    public class ConfigurationJson
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
