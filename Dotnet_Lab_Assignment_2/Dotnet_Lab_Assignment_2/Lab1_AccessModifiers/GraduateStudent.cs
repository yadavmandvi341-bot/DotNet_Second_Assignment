using System;

namespace Lab1_AccessModifiers
{
    // Lab Question 3: Inheritance within the Same Assembly
    public class GraduateStudent : Student
    {
        public void ShowData()
        {
            SetData("Priya", 23, "MCA", 9.1, "GLA University", "Delhi");

            Console.WriteLine("----- GraduateStudent.ShowData() -----");
            Console.WriteLine(">> Accessing INHERITED members directly (as own members):");

            // Name -> public -> ACCESSIBLE
            Console.WriteLine("Name       : " + Name);

            // Age -> private -> NOT ACCESSIBLE (private members are never inherited-accessible)
            // Console.WriteLine(Age);
            // ERROR: 'Student.Age' is inaccessible due to its protection level.

            // Department -> protected -> ACCESSIBLE (derived class, any assembly)
            Console.WriteLine("Department : " + Department);

            // CGPA -> internal -> ACCESSIBLE (same assembly)
            Console.WriteLine("CGPA       : " + CGPA);

            // College -> protected internal -> ACCESSIBLE (derived class OR same assembly)
            Console.WriteLine("College    : " + College);

            // Address -> private protected -> ACCESSIBLE
            // (GraduateStudent IS a derived class AND IS in the same assembly -> both conditions met)
            Console.WriteLine("Address    : " + Address);

            Console.WriteLine();
            Console.WriteLine(">> Accessing members THROUGH AN OBJECT of Student (base type):");
            Student obj = new Student();
            obj.SetData("Sample", 20, "IT", 7.0, "GLA University", "Agra");

            // Name -> public -> ACCESSIBLE
            Console.WriteLine("obj.Name       : " + obj.Name);

            // Age -> private -> NOT ACCESSIBLE
            // Console.WriteLine(obj.Age);

            // Department -> protected -> NOT ACCESSIBLE through a BASE-TYPE object reference
            // Console.WriteLine(obj.Department);
            // ERROR: C# rule -> a protected member can be accessed through an instance
            // ONLY if the instance's compile-time type is the derived class itself
            // (or a class derived from it) -- NOT the base class type.
            // Here 'obj' is declared as type Student (the base class), so access is denied
            // even though we are physically inside GraduateStudent.

            // CGPA -> internal -> ACCESSIBLE (internal only cares about assembly, not instance type)
            Console.WriteLine("obj.CGPA       : " + obj.CGPA);

            // College -> protected internal -> ACCESSIBLE via its "internal" half (same assembly)
            Console.WriteLine("obj.College    : " + obj.College);

            // Address -> private protected -> NOT ACCESSIBLE through base-type object reference
            // Console.WriteLine(obj.Address);
            // ERROR: same reasoning as 'protected' above -- the base-instance restriction
            // also applies to the "protected" half of private protected.
        }
    }

    /* =========================================================================================
       SUMMARY TABLE - Lab Question 3 (GraduateStudent : Student, same assembly)
       =========================================================================================
       Member      | Modifier            | Via Inheritance | Via Student object  | Reason (object case)
       ------------|---------------------|------------------|---------------------|---------------------------------
       Name        | public              | YES              | YES                 | Always open
       Age         | private             | NO               | NO                  | Only inside declaring class
       Department  | protected           | YES              | NO                  | Base-typed instance not allowed
       CGPA        | internal            | YES              | YES                 | Same assembly is enough
       College     | protected internal  | YES              | YES                 | Internal half covers it
       Address     | private protected   | YES              | NO                  | Base-typed instance not allowed
       =========================================================================================
       KEY TAKEAWAY: Inheritance gives more access than going through a base-class-typed
       object, because C# only allows protected / private protected access through an
       instance whose compile-time type is the derived class (or further derived) — not
       through a variable declared as the base class type.
    */
}
