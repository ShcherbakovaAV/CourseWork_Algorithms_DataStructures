using CourseWork.Structures.ElementsStructure;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseWork.Structures.Structure
{
    public class Airport : IEnumerable<Airplane>
    {
        private string _name;
        public string Name => _name;

        private ElementSecondaryStructure _head;

        private int _count;
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        private bool _isEmpty => Count == 0;
        public bool IsEmpty
        {
            get { return _isEmpty; }
        }

        public Airport(string name)
        {
            _name = name;
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
                throw new InvalidOperationException("Самолетов в аэропорту нет");

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
            ElementSecondaryStructure _current = _head;

            while (_current != null)
            {
                ElementSecondaryStructure temp = _current;
                _current = _current.Next;
                temp.Airplane = null;
                temp = null;
            }
            _head = null;
            Count = 0;
        }

        public IEnumerator<Airplane> GetEnumerator()
        {
            ElementSecondaryStructure _current = _head;

            while (_current != null)
            {
                yield return _current.Airplane;

                _current = _current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
