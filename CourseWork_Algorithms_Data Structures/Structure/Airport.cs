using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class Airport
    {
        public string Name { get; private set; }

        private ElementSecondaryStructure _head;

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public Airport(string name)
        {
            Name = name;
        }

        public void Push(Airplane airplane)
        {
            if (airplane is null)
                throw new ArgumentNullException(nameof(airplane));

            ElementSecondaryStructure node = new ElementSecondaryStructure(airplane);

            node.Next = _head;
            _head = node;

            Count++;
        }

        public Airplane Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Airplane result = _head.Airplane;
            _head = _head.Next;

            Count--;
            return result;
        }

        public Airplane Peek()
        {
            return _head.Airplane;
        }

        public Airplane Contains_Airplane(string brand, int year)
        {
            ElementSecondaryStructure _current = _head;

            while (_current != null)
            {
                if (_current.Airplane.Brand == brand && _current.Airplane.YearofManufacture == year)
                    return _current.Airplane;

                _current = _current.Next;
            }

            return null;
        }

        

        public void Clear()
        {
            _head = null;
        }
    }
}
