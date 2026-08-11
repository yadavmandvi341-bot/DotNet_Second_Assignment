using Student2;

using System;
using System.Xml.Linq;

class ResearchStudent : Student
{
    public void ShowData()
    {

        Console.WriteLine("Name: " + name);      // Accessible
        Console.WriteLine("Course: " + course);  // Accessible
        Console.WriteLine("Age: " + age);        // Accessible


        Student s = new Student();


        Console.WriteLine("Age: " + s.age); // Accessible
    }

    static void Main(string[] args)
    {
        ResearchStudent rs = new ResearchStudent();
        rs.ShowData();
    }
}