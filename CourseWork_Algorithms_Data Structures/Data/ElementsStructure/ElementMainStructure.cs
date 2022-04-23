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
