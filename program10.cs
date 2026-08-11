using System;

class LabQuestion3
{
    private int id = 101;
    protected string name = "Kartik";
    internal string course = "MCA";
    public int age = 22;
}

class GraduateStudent : LabQuestion3
{
    public void ShowData()
    {

        Console.WriteLine("Name: " + name);
        Console.WriteLine("Course: " + course);
        Console.WriteLine("Age: " + age);


        LabQuestion3 l = new LabQuestion3();


        Console.WriteLine("Course: " + l.course);
        Console.WriteLine("Age: " + l.age);
    }

    static void Main1(string[] args)
    {
        GraduateStudent gs = new GraduateStudent();
        gs.ShowData();
    }
}