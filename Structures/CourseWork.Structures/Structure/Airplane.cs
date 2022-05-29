namespace CourseWork.Structures.Structure
{
    public class Airplane
    {
        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private int _yearOfManufacture;
        public int YearofManufacture
        {
            get { return _yearOfManufacture; }
            set { _yearOfManufacture = value; }
        }

        public Airplane(string Brand, int YearofManufacture)
        {
            this.Brand = Brand;
            this.YearofManufacture = YearofManufacture;
        }

        public void Clear()
        {
            this._brand = null;
            this._yearOfManufacture = 0;
        }
    }
}
