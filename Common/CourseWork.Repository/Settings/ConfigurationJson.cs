namespace CourseWork.Repository.Settings
{
    public class ConfigurationJson
    {
        private string _fileInput { get; set; }
        /// <summary>
        /// Путь файла, по которому загружаем структуру
        /// </summary>
        public string FileInput
        {
            get { return _fileInput; }
            set { _fileInput = value; }
        }

        private string _fileOutput { get; set; }
        /// <summary>
        /// Путь файла, из которого загружаем структуру
        /// </summary>
        public string FileOutput
        {
            get { return _fileOutput; }
            set { _fileOutput = value; }
        }
    }
}
