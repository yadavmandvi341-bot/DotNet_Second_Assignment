using System;

namespace Lab1_AccessModifiers
{
    // Lab Question 2: Access Modifiers within the Same Assembly
    // TestStudent is NOT related to Student by inheritance, but lives in the same assembly.
    public class TestStudent
    {
        public void AccessMembers()
        {
            Student s = new Student();
            s.SetData("Rahul", 21, "CSE", 8.5, "GLA University", "Mathura, UP");

            Console.WriteLine("----- TestStudent.AccessMembers() -----");

            // 1. Name -> public -> ACCESSIBLE from anywhere
            Console.WriteLine("Name    : " + s.Name);

            // 2. Age -> private -> NOT ACCESSIBLE
            // Console.WriteLine(s.Age);
            // ERROR: 'Student.Age' is inaccessible due to its protection level.
            // Reason: private members are visible only inside the declaring class itself.

            // 3. Department -> protected -> NOT ACCESSIBLE
            // Console.WriteLine(s.Department);
            // ERROR: 'Student.Department' is inaccessible due to its protection level.
            // Reason: protected members are visible only inside the declaring class
            // and in classes that INHERIT from it. TestStudent does not inherit Student.

            // 4. CGPA -> internal -> ACCESSIBLE (same assembly)
            Console.WriteLine("CGPA    : " + s.CGPA);
            // Reason: internal members are visible to any code in the same assembly,
            // regardless of inheritance.

            // 5. College -> protected internal -> ACCESSIBLE (same assembly)
            Console.WriteLine("College : " + s.College);
            // Reason: protected internal = protected OR internal.
            // Since TestStudent is in the same assembly, the "internal" part grants access.

            // 6. Address -> private protected -> NOT ACCESSIBLE
            // Console.WriteLine(s.Address);
            // ERROR: 'Student.Address' is inaccessible due to its protection level.
            // Reason: private protected = protected AND internal (both conditions required).
            // TestStudent is in the same assembly but is NOT a derived class of Student,
            // so the "derived class" condition fails -> access denied.
        }
    }

    /* =========================================================================
       SUMMARY TABLE - Lab Question 2 (TestStudent, same assembly, no inheritance)
       =========================================================================
       Member       | Modifier            | Accessible? | Reason
       -------------|---------------------|-------------|---------------------------------
       Name         | public              | YES         | Open to everyone
       Age          | private             | NO          | Only inside declaring class
       Department   | protected           | NO          | Needs inheritance, not just same assembly
       CGPA         | internal            | YES         | Same assembly is enough
       College      | protected internal  | YES         | Same assembly satisfies OR condition
       Address      | private protected   | NO          | Needs BOTH same assembly AND inheritance
       ========================================================================= */
}
