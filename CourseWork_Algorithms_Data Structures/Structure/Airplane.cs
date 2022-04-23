namespace CourseWork_Algorithms_Data_Structures
{
    public class Airplane
    {
        public string Brand { get; private set; }

        public int YearofManufacture { get; private set; }

        public Airplane(string Brand, int YearofManufacture)
        {
            this.Brand = Brand;
            this.YearofManufacture = YearofManufacture;
        }
    }
}
