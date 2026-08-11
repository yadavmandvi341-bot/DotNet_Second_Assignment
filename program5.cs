using System;

class Student
{

    public int Id;
    public string Name;
    public int Age;

    // Display method
    public void Display()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
    }

    static void Main(string[] args)
    {
        Student s = new Student();

        s.Id = 101;
        s.Name = "Kartik";
        s.Age = 22;

        s.Display();
    }
}