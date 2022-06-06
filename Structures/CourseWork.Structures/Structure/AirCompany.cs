using CourseWork.Structures.ElementsStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.Structures.Structure
{
    public class AirCompany : IEnumerable<Airport>
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private ElementMainStructure _head { get; set; }

        private ElementMainStructure _tail { get; set; }

        public AirCompany(string name)
        {
            Name = name;
        }

        private int _countAirport;
        public int CountAirport
        {
            get { return _countAirport; }
            set { _countAirport = value; }
        }

        private int _countAirplane => this.Sum(airport => airport.Count);
        public int CountAirplane
        {
            get { return _countAirplane; }
        }

        private bool _isEmpty => CountAirport == 0;
        public bool IsEmpty
        {
            get { return _isEmpty; }
        } 

        public void PushAirport(Airport airport)
        {
            ElementMainStructure node = new ElementMainStructure(airport);

            if (CountAirport == 0)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            CountAirport++;
        }

        public void PushAirport(string name_airport)
        {
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
            Airplane airplane = new Airplane(brand, year);

            PushAirplane(airplane, name_airport);
        }

        public Airport PopAirport()
        {
            if (IsEmpty)
                throw new InvalidOperationException("В компании нет аэропортов");

            Airport result = _head.Airport;

            if (CountAirport == 1)
            {
                _head = null;
                _tail = null;
            }
            else
                _head = _head.Next;

            CountAirport--;

            return result;
        }

        public Airplane PopAirplane(string name_airport)
        {
            if (IsEmpty)
                throw new InvalidOperationException("В компании нет аэропортов с самолетами");

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

        public Airplane Contains_Airplane(string brand, int year, out string name_airport)
        {
            ElementMainStructure _current = _head;

            name_airport = null;

            while (_current != null)
            {
                name_airport = _current.Airport.Name;

                Airplane airplane = _current.Airport.Contains_Airplane(brand, year);

                if (airplane != null)
                    return airplane;

                _current = _current.Next;
            }

            return null;
        }

        public void Clear()
        {
            ElementMainStructure _current = _head;

            while (_current != null)
            {
                ElementMainStructure temp = _current;
                _current = _current.Next;
                temp.Airport.Clear();
                temp.Airport = null;
                temp = null;
            }

            _head = null;
            _tail = null;
            CountAirport = 0;
            Name = "";
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
