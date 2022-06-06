namespace CourseWork.Repository.Settings
{
    /// <summary>
    /// Класс, для рабоыт с настройками
    /// </summary>
    public class Configuration
    {
        private ConfigurationJson _json;
        private ConfigurationXml _xml;
        public ConfigurationXml Xml
        {
            get { return _xml; }
            set { _xml = value; }
        }
        public ConfigurationJson Json
        {
            get { return _json; }
            set { _json = value; }
        }
    }
}
