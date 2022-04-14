using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork_Algorithms_Data_Structures
{
    public class AirCompany : IEnumerable<Airport>
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

        public void PushAirport(Airport airport)
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

        public void PushAirport(string name_airport)
        {
            if (name_airport is null)
                throw new ArgumentNullException(nameof(name_airport));

            Airport airport = new Airport(name_airport);
            PushAirport(airport);
        }

        public void PushAirplane(Airplane airplane, string name_airport)
        {
            Airport airport = Contains_Airport(name_airport);

            if (airport is null)
                throw new ArgumentException("Такого аэропорта нет");

            airport.Push(airplane);
        }

        public void PushAirplane(string brand, int year, string name_airport)
        {
            if (brand is null || year == 0)
                throw new ArgumentNullException();

            Airplane airplane = new Airplane(brand, year);

            PushAirplane(airplane, name_airport);
        }

        public Airport PopAirport()
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

        public Airplane PopAirplane(string name_airport)
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Airport airport = Contains_Airport(name_airport);

            if (airport is null)
                throw new ArgumentException("Такого аэропорта нет");
            
            return airport.Pop();

        }

        public Airport Contains_Airport(string name_airport)
        {
            ElementMainStructure _current = _head;

            while (_current != null)
            {
                if (_current.Airport.Name == name_airport)
                    return _current.Airport;

                _current = _current.Next;
            }

            return null;
        }

        public Airplane Contains_Airplane(string brand, int year)
        {
            ElementMainStructure _current = _head;

            while (_current != null)
            {
                Airplane airplane = _current.Airport.Contains_Airplane(brand, year);

                if (airplane != null)
                    return airplane;

                _current = _current.Next;
            }

            return null;
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

        public IEnumerator<Airport> GetEnumerator()
        {
            ElementMainStructure _current = _head;

            while (_current != null)
            {
                yield return _current.Airport;

                _current = _current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
