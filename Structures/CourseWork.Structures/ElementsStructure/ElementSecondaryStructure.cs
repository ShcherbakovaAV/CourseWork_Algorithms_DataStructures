using CourseWork.Structures.Structure;

namespace CourseWork.Structures.ElementsStructure
{
    public class ElementSecondaryStructure
    {
        public Airplane Airplane { get; set; }

        public ElementSecondaryStructure Next { get; set; }

        public ElementSecondaryStructure(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
