using System;

namespace Lab1_AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(" LAB QUESTION 1: Access Modifiers within the SAME CLASS");
            Console.WriteLine("=====================================================");
            Student s1 = new Student();
            s1.SetData("Abhi", 22, "MCA", 8.9, "GLA University", "Faridabad, Haryana");
            s1.Display();
            // Inside the Student class itself, every member (public, private, protected,
            // internal, protected internal, private protected) is fully accessible.
            // Access restrictions only matter when OTHER classes try to reach these members.

            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.WriteLine(" LAB QUESTION 2: Access Modifiers within the SAME ASSEMBLY");
            Console.WriteLine("=====================================================");
            TestStudent test = new TestStudent();
            test.AccessMembers();

            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.WriteLine(" LAB QUESTION 3: Inheritance within the SAME ASSEMBLY");
            Console.WriteLine("=====================================================");
            GraduateStudent grad = new GraduateStudent();
            grad.ShowData();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
