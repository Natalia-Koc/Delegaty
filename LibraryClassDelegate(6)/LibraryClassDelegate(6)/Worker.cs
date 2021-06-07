using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClassDelegate_6_
{
    public class Worker 
    {
        //staż, liczbą sprzedaży, pensja
        public int Identifier { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Internship { get; set; }
        public int NumberOfSales { get; set; }
        public float Salary { get; set; }

        public Worker(int identifier, string name, string surname, string internship, int numberOfSales, float salary)
        {
            Identifier = identifier;
            Name = name;
            Surname = surname;
            Internship = internship;
            NumberOfSales = numberOfSales;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
