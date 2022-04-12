using System;

namespace CourseWork_Algorithms_Data_Structures
{
    public class Program
    {
        static void Main(string[] args)
        {
            Airport airport = new Airport("Kazan");

            Airplane airplane1 = new Airplane("BRE", 1956);
            Airplane airplane2 = new Airplane("DVC", 2000);
            Airplane airplane3 = new Airplane("UIR", 2005);

            airport.Push(airplane1);
            airport.Push(airplane2);
            airport.Push(airplane3);

            Airport airport2 = new Airport("Moscow");

            Airplane airplane6 = new Airplane("YRE", 2001);
            Airplane airplane4 = new Airplane("KLI", 2007);
            Airplane airplane5 = new Airplane("PWQ", 2008);

            airport2.Push(airplane4);
            airport2.Push(airplane5);
            airport2.Push(airplane6);

            AirCompany company = new AirCompany("Победа");

            company.Push(airport);
            company.Push(airport2);
        }
    }
}
