using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
