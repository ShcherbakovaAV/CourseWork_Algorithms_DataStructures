﻿namespace CourseWork.Structures.Structure
{
    public class Airplane
    {
        public string Brand { get; set; }

        public int YearofManufacture { get; set; }

        public Airplane(string Brand, int YearofManufacture)
        {
            this.Brand = Brand;
            this.YearofManufacture = YearofManufacture;
        }
    }
}
