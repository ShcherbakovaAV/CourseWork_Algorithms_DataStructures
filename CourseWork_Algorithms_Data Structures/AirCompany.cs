using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class AirCompany
    {
        public string Name { get; set; }

        private ElementMainStructure _head { get; set; }

        private ElementMainStructure _tail { get; set; }

        public AirCompany(string name)
        {
            Name = name;
        }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Push(Airport airport)
        {
            if (airport is null)
                throw new ArgumentNullException(nameof(airport));

            ElementMainStructure node = new ElementMainStructure(airport);

            if (Count == 0)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void Push(string name_airport)
        {
            if (name_airport is null)
                throw new ArgumentNullException(nameof(name_airport));

            Airport airport = new Airport(name_airport);
            Push(airport);
        }

        public Airport Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Airport result = _head.Airport;

            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
                _head = _head.Next;

            Count--;

            return result;
        }

        public Airport Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Очередь пуста");
            return _head.Airport;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;  
        }
    }
}
