using CourseWork.Structures.Structure;

namespace CourseWork.Structures.ElementsStructure
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
