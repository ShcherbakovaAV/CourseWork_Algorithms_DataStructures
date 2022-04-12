using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class ElementMainStructure
    {
        public ElementMainStructure Next { get; set; }

        public Airport Airport { get; set; }

        public ElementMainStructure(Airport airport)
        {
            Airport = airport;
        }
    }
}
