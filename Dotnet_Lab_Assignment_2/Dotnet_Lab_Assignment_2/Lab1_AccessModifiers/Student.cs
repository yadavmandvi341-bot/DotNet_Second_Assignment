using System;

namespace Lab1_AccessModifiers
{
    public class Student
    {
        public string Name;                 // Accessible everywhere
        private int Age;                    // Accessible only inside Student class
        protected string Department;        // Accessible in Student + derived classes
        internal double CGPA;               // Accessible anywhere in same assembly
        protected internal string College;  // Accessible in same assembly OR in derived classes (any assembly)
        private protected string Address;   // Accessible in same assembly AND only in derived classes

        // Public method to set values (so Display() has something to show)
        public void SetData(string name, int age, string department, double cgpa, string college, string address)
        {
            Name = name;
            Age = age;
            Department = department;
            CGPA = cgpa;
            College = college;
            Address = address;
        }

        // Public method that prints all member values
        public void Display()
        {
            // Inside the SAME class, ALL access modifiers are accessible without restriction
            Console.WriteLine("----- Student.Display() -----");
            Console.WriteLine("Name (public)              : " + Name);
            Console.WriteLine("Age (private)               : " + Age);
            Console.WriteLine("Department (protected)       : " + Department);
            Console.WriteLine("CGPA (internal)              : " + CGPA);
            Console.WriteLine("College (protected internal) : " + College);
            Console.WriteLine("Address (private protected)  : " + Address);
        }
    }
}
