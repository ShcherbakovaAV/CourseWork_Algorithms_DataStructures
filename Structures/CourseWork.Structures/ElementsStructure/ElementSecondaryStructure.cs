using CourseWork.Structures.Structure;

namespace CourseWork.Structures.ElementsStructure
{
    public class ElementSecondaryStructure
    {
        private Airplane _airplane;
        public Airplane Airplane 
        {
            get { return _airplane; }
            set { _airplane = value; }
        }

        private ElementSecondaryStructure _next;
        public ElementSecondaryStructure Next 
        {
            get { return _next; }
            set { _next = value; }
        }

        public ElementSecondaryStructure(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
