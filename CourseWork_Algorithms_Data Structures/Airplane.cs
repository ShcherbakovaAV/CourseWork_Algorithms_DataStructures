using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class Airplane
    {
        public string Brand { get; private set; }

        public string YearofManufacture { get; private set; }

        public Airplane(string Brand, string YearofManufacture)
        {
            this.Brand = Brand;
            this.YearofManufacture = YearofManufacture;
        }
    }
}
