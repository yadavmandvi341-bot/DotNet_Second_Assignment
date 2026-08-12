using System;
using StudentLibrary;

namespace StudentClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine(" LAB QUESTION 4: Access Modifiers ACROSS Assemblies");
            Console.WriteLine(" (StudentClient using Student from StudentLibrary)");
            Console.WriteLine("=====================================================");

            Student s = new Student();
            s.SetData("Rohit", 22, "MBA", 8.0, "GLA University", "Faridabad");

            // Name -> public -> ACCESSIBLE
            Console.WriteLine("Name    : " + s.Name);

            // Age -> private -> NOT ACCESSIBLE
            // Console.WriteLine(s.Age);
            // ERROR: private never leaves the declaring class.

            // Department -> protected -> NOT ACCESSIBLE
            // Console.WriteLine(s.Department);
            // ERROR: no inheritance here, and different assembly -> protected fails.

            // CGPA -> internal -> NOT ACCESSIBLE
            // Console.WriteLine(s.CGPA);
            // ERROR: internal only works within the SAME assembly. StudentClient is a
            // different assembly from StudentLibrary -> access denied.

            // College -> protected internal -> NOT ACCESSIBLE
            // Console.WriteLine(s.College);
            // ERROR: protected internal = protected OR internal.
            // Different assembly -> internal fails. No inheritance -> protected fails.
            // Both halves fail -> inaccessible.

            // Address -> private protected -> NOT ACCESSIBLE
            // Console.WriteLine(s.Address);
            // ERROR: private protected = protected AND internal. Both fail here.

            Console.WriteLine();
            Console.WriteLine(">>> TABLE: Lab 4 - Student accessed from StudentClient (no inheritance)");
            Console.WriteLine("Member      | Modifier            | Accessible | Reason");
            Console.WriteLine("Name        | public              | YES        | Open to everyone");
            Console.WriteLine("Age         | private             | NO         | Only inside declaring class");
            Console.WriteLine("Department  | protected           | NO         | Needs a derived class, none here");
            Console.WriteLine("CGPA        | internal            | NO         | Different assembly");
            Console.WriteLine("College     | protected internal  | NO         | Diff. assembly AND no inheritance");
            Console.WriteLine("Address     | private protected   | NO         | Diff. assembly AND no inheritance");

            Console.WriteLine();
            Console.WriteLine("=====================================================");
            Console.WriteLine(" LAB QUESTION 5: Inheritance ACROSS Assemblies");
            Console.WriteLine("=====================================================");
            ResearchStudent rs = new ResearchStudent();
            rs.ShowInheritedAccess();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
