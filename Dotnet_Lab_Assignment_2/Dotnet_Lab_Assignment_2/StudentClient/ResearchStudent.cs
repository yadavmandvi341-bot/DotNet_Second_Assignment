using System;
using StudentLibrary;

namespace StudentClient
{
    // Lab Question 5: Inheritance Across Different Assemblies
    // ResearchStudent lives in StudentClient assembly, but inherits Student
    // from the StudentLibrary assembly.
    public class ResearchStudent : Student
    {
        public void ShowInheritedAccess()
        {
            SetData("Neha", 24, "M.Tech", 8.7, "GLA University", "Noida");

            Console.WriteLine("----- ResearchStudent (different assembly): via inheritance -----");

            // Name -> public -> ACCESSIBLE
            Console.WriteLine("Name       : " + Name);

            // Age -> private -> NOT ACCESSIBLE
            // Console.WriteLine(Age);
            // ERROR: private is never accessible outside the declaring class, any assembly.

            // Department -> protected -> ACCESSIBLE
            Console.WriteLine("Department : " + Department);
            // Reason: protected works across assemblies too, as long as we are in a
            // DERIVED class. Assembly boundary does not matter for plain 'protected'.

            // CGPA -> internal -> NOT ACCESSIBLE
            // Console.WriteLine(CGPA);
            // ERROR: 'Student.CGPA' is inaccessible due to its protection level.
            // Reason: internal only works within the SAME assembly. Inheritance across
            // assemblies does NOT unlock internal members.

            // College -> protected internal -> ACCESSIBLE
            Console.WriteLine("College    : " + College);
            // Reason: protected internal = protected OR internal.
            // We are in a different assembly (internal part fails) BUT we ARE a derived
            // class (protected part succeeds) -> OR condition satisfied -> accessible.

            // Address -> private protected -> NOT ACCESSIBLE
            // Console.WriteLine(Address);
            // ERROR: 'Student.Address' is inaccessible due to its protection level.
            // Reason: private protected = protected AND internal (both required).
            // We satisfy "derived class" but NOT "same assembly" -> AND condition fails.

            Console.WriteLine();
            Console.WriteLine("----- ResearchStudent (different assembly): via Student object -----");
            Student obj = new Student();
            obj.SetData("Sample2", 21, "BCA", 7.5, "GLA University", "Mathura");

            // Name -> public -> ACCESSIBLE
            Console.WriteLine("obj.Name    : " + obj.Name);

            // Age -> private -> NOT ACCESSIBLE
            // Department -> protected -> NOT ACCESSIBLE
            //   (base-typed instance rule, same as Lab3, PLUS different assembly)
            // CGPA -> internal -> NOT ACCESSIBLE (different assembly)
            // College -> protected internal -> NOT ACCESSIBLE
            //   (different assembly kills 'internal' half AND base-typed instance kills
            //    the 'protected' half -> both halves fail this time)
            // Address -> private protected -> NOT ACCESSIBLE

            Console.WriteLine("(Age, Department, CGPA, College, Address are all INACCESSIBLE");
            Console.WriteLine(" through a Student-typed object from a different assembly.)");
        }
    }

    /* ==========================================================================================
       SUMMARY TABLE - Lab Question 5 (ResearchStudent : Student, DIFFERENT assembly)
       ==========================================================================================
       Member      | Modifier            | Via Inheritance | Via Student object | Reason
       ------------|---------------------|------------------|---------------------|------------------------------
       Name        | public              | YES              | YES                 | Always open
       Age         | private             | NO               | NO                  | Never leaves declaring class
       Department  | protected           | YES              | NO                  | Works cross-assembly via inheritance;
                    |                     |                  |                     | fails via base-typed object
       CGPA        | internal            | NO               | NO                  | Different assembly -> fails
       College     | protected internal  | YES              | NO                  | 'protected' half saves it via
                    |                     |                  |                     | inheritance; both halves fail via object
       Address     | private protected   | NO               | NO                  | Needs BOTH same assembly AND
                    |                     |                  |                     | derived class -> assembly fails
       ==========================================================================================

       COMPARISON: protected vs protected internal vs private protected (cross-assembly)
       ----------------------------------------------------------------------------------
       - protected            : works in ANY assembly, as long as you are in a derived class.
       - protected internal   : works if EITHER same assembly OR derived class is true
                                 (easiest to satisfy - an OR condition).
       - private protected    : works only if BOTH same assembly AND derived class are true
                                 (hardest to satisfy - an AND condition). This is why Address
                                 fails here even though ResearchStudent does inherit Student -
                                 the assembly condition still isn't met.
    */
}
