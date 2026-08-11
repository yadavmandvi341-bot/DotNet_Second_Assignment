using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_AccessModifiers
{
    class Student
    {
        public string name;
        private int Age; // Not accessible outside the class
        protected string Department; // Not accessible outside the class and derived classes
        internal double CGPA;
        protected internal string College;
        private protected string Address; // Not accessible outside the class and derived classes in the same assembly


    }
    class Program
    {
        static void Main(String[] args)
        {
            Student s = new Student();
            s.name = "Kartik";
            s.CGPA = 9.5;
            s.College = "GLA";

            Console.WriteLine("Name: " + s.name);
            Console.WriteLine("CGPA: " + s.CGPA);
            Console.WriteLine("College: " + s.College);
        }
    }

}