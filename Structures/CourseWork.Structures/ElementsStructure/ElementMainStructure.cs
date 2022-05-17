using CourseWork.Structures.Structure;

namespace CourseWork.Structures.ElementsStructure
{
    public class ElementMainStructure
    {
        private ElementMainStructure _next;
        public ElementMainStructure Next 
        {
            get { return _next; }
            set { _next = value; }
        }

        private Airport _airport;
        public Airport Airport 
        {
            get { return _airport; }
            set { _airport = value; }
        }


        public ElementMainStructure(Airport airport)
        {
            Airport = airport;
        }
    }
}
