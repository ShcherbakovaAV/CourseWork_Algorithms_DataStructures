using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class ElementSecondaryStructure
    {
        public Airplane Airplane { get; private set; }

        public ElementSecondaryStructure Next { get; private set; }

        public ElementSecondaryStructure(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
