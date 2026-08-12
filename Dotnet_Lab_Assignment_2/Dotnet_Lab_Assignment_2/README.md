# .NET Framework Lab Assignment 2 — Access Modifiers

## Folder Structure

```
DotNet_Lab_Assignment2/
├── Lab1_AccessModifiers/     -> Console App (covers Lab Q1, Q2, Q3)
│   ├── Student.cs
│   ├── TestStudent.cs
│   ├── GraduateStudent.cs
│   └── Program.cs
├── StudentLibrary/           -> Class Library (used for Lab Q4, Q5)
│   └── Student.cs
└── StudentClient/            -> Console App referencing StudentLibrary (Lab Q4, Q5)
    ├── ResearchStudent.cs
    └── Program.cs
```

## How to Run (2 Options)

### Option A: Visual Studio
1. Open Visual Studio -> **Create a new project** -> Blank Solution, name it `DotNet_Lab_Assignment2`.
2. Right-click solution -> Add -> Existing Project -> add all three `.csproj` files
   (`Lab1_AccessModifiers`, `StudentLibrary`, `StudentClient`).
3. In `StudentClient`, the reference to `StudentLibrary` is already set up in the `.csproj`
   (equivalent to Add Reference -> Project -> StudentLibrary).
4. Right-click `Lab1_AccessModifiers` -> Set as Startup Project -> Run (F5) to see Lab 1-3 output.
5. Right-click `StudentClient` -> Set as Startup Project -> Run (F5) to see Lab 4-5 output.

### Option B: dotnet CLI
```bash
cd Lab1_AccessModifiers
dotnet run

cd ../StudentClient
dotnet run
```

## Answers / Explanation (also commented inline in the .cs files)

### Lab Q1 — Same Class
Inside the `Student` class itself, **every** member (`public`, `private`, `protected`,
`internal`, `protected internal`, `private protected`) is fully accessible. Access
modifiers only restrict access from **outside** the declaring class — they never restrict
the class from using its own members.

### Lab Q2 — Same Assembly, No Inheritance (`TestStudent`)
| Member | Modifier | Accessible? | Reason |
|---|---|---|---|
| Name | public | YES | Open to everyone |
| Age | private | NO | Only inside declaring class |
| Department | protected | NO | Needs inheritance, same assembly isn't enough |
| CGPA | internal | YES | Same assembly is enough |
| College | protected internal | YES | OR condition — same assembly satisfies it |
| Address | private protected | NO | AND condition — needs inheritance too |

### Lab Q3 — Inheritance, Same Assembly (`GraduateStudent`)
| Member | Modifier | Via Inheritance | Via `Student` object | Why object case differs |
|---|---|---|---|---|
| Name | public | YES | YES | Always open |
| Age | private | NO | NO | Never leaves declaring class |
| Department | protected | YES | NO | C# blocks protected access through a base-typed instance |
| CGPA | internal | YES | YES | Internal ignores instance type, only cares about assembly |
| College | protected internal | YES | YES | Internal half still works |
| Address | private protected | YES | NO | Same base-typed-instance restriction as protected |

**Key rule:** C# only allows `protected`/`private protected` access through an object
reference whose *compile-time type* is the derived class itself (or further derived) —
not the base class type — even from inside the derived class's own code.

### Lab Q4 — Different Assemblies, No Inheritance (`StudentClient` → `StudentLibrary`)
| Member | Modifier | Accessible? | Reason |
|---|---|---|---|
| Name | public | YES | Open to everyone |
| Age | private | NO | Only inside declaring class |
| Department | protected | NO | No inheritance here |
| CGPA | internal | NO | Different assembly |
| College | protected internal | NO | Different assembly AND no inheritance (both halves fail) |
| Address | private protected | NO | Different assembly AND no inheritance |

### Lab Q5 — Inheritance Across Assemblies (`ResearchStudent : Student`)
| Member | Modifier | Via Inheritance | Via `Student` object |
|---|---|---|---|
| Name | public | YES | YES |
| Age | private | NO | NO |
| Department | protected | YES | NO |
| CGPA | internal | NO | NO |
| College | protected internal | YES | NO |
| Address | private protected | NO | NO |

**protected vs protected internal vs private protected (cross-assembly):**
- `protected` → works in **any** assembly, as long as you're in a derived class.
- `protected internal` → **OR** condition: same assembly **OR** derived class. Easiest to satisfy.
- `private protected` → **AND** condition: same assembly **AND** derived class. Hardest to satisfy —
  this is why `Address` fails in Lab 5 even though `ResearchStudent` does inherit `Student`.
