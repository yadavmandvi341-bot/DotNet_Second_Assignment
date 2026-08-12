using System;

namespace StudentLibrary
{
    // Same Student class as Lab1, now moved into its own Class Library
    // assembly (StudentLibrary.dll) so we can test cross-assembly access.
    public class Student
    {
        public string Name;
        private int Age;
        protected string Department;
        internal double CGPA;
        protected internal string College;
        private protected string Address;

        public void SetData(string name, int age, string department, double cgpa, string college, string address)
        {
            Name = name;
            Age = age;
            Department = department;
            CGPA = cgpa;
            College = college;
            Address = address;
        }

        public void Display()
        {
            Console.WriteLine("----- Student.Display() -----");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("CGPA: " + CGPA);
            Console.WriteLine("College: " + College);
            Console.WriteLine("Address: " + Address);
        }
    }
}
