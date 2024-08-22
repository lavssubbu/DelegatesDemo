// See https://aka.ms/new-console-template for more information
using LINQConcepts;

Console.WriteLine("Hello, World!");


int[] arr = { 10, 20, 23, 26, 29, 30 };
//Deffered execution - Late
var result = from ar in arr
             where ar%2 == 0
             select ar;

foreach(int it in result)
{
    Console.WriteLine(it);
}

//Immediate execution - Fast performance
IList<int> res = (from ar in arr
             where ar % 2 == 0
             select ar).ToList();

foreach (int it in res)
{
    Console.WriteLine(it);
}

List<Product>? lstpro = new List<Product>()
{
    new Product(){proId=111,proName="Laptop",propPrice=80000,CName="Electronics"},
     new Product(){proId=121,proName="Mac",propPrice=99999,CName="Apple"},
      new Product(){proId=131,proName="iPhone",propPrice=85000,CName="Apple"},
       new Product(){proId=141,proName="HardDisk",propPrice=8000,CName="Electronics"},
        new Product(){proId=151,proName="Laptop",propPrice=75000,CName="Electronics"}
};

List<Category>? lstcat = new List<Category>()
{
    new Category(){catId=1,Name="Electronics"},
    new Category(){catId=2,Name="Clothing"}
};
IEnumerable<Product> lst = lstpro.Where(x => x.proName.Equals("Laptop")).ToList();

foreach(Product p in lst)
{
    Console.WriteLine(p.proId+" "+p.proName+" "+p.propPrice);
}

var re =   from lsts in lstpro
           join lstc in lstcat
           on lsts.CName equals lstc.Name 
           select lsts;

foreach(Product p in re)
{
    Console.WriteLine(p.proName + " "+p.CName);
}
//lstpro Outer sequence
var innerjoin = lstpro.Join(lstcat,//Inner sequence
    lsp => lsp.CName, //Keyselector for product
   lsc => lsc.Name,//Keyselector for category
    (lsp, lsc) => new //Projection REsult
    {
        cname = lsp.CName,
        caname = lsc.Name,
        pname = lsp.proName
    }
    );


foreach (var p in innerjoin)
{
    Console.WriteLine(p.pname+" "+p.caname);
}
IList<Department> lstdpt = new List<Department>()
{
    new Department(){Deptid=111,DeptName="HR"},
     new Department(){Deptid=112,DeptName="Developer"}
     // new Department(){Deptid=113,DeptName="Testing"}
};
IList<Employee> employees = new List<Employee>()
{
    new Employee(){Empid=1001,EmpName="Shri",Dname="Developer"},
    new Employee(){Empid=1002,EmpName="Raghav",Dname="HR"},
    new Employee(){Empid=1003,EmpName="Madhav",Dname="Developer"},
    new Employee(){Empid=1004,EmpName="Susheel",Dname="Developer"},
    new Employee(){Empid=1005,EmpName="Shree",Dname="Testing"}

};
var projects = new List<Project>
{
    new Project { ProjectId = 1, Title = "FinancialApp" },
    new Project { ProjectId = 2, Title = "HealthCare" },
    new Project { ProjectId = 3, Title = "Payroll" }
};

var assignments = new List<ProjectAssigned>
{
    new ProjectAssigned { EmployeeId = 1001, ProjectId = 1 },
    new ProjectAssigned { EmployeeId = 1001, ProjectId = 2 },
    new ProjectAssigned { EmployeeId = 1002, ProjectId = 2 },
    new ProjectAssigned { EmployeeId = 1002, ProjectId = 3 },
    new ProjectAssigned { EmployeeId = 1003, ProjectId = 1 }
};

// 1. Filter: Employees assigned to at least two projects
var employeesInMultipleProjects = employees
    .Where(employee => assignments.Count(a => a.EmployeeId == employee.Empid) >= 2)
    .Select(employee => employee.EmpName)
    .ToList();

Console.WriteLine("Employees assigned to at least two projects:");
foreach (var employee in employeesInMultipleProjects)
{
    Console.WriteLine(employee);
}

// 2. Group: Employees by their department
var employeesGroupedByDepartment = employees
    .GroupBy(employee => employee.Dname)
     //  .Select(employee => employee.EmpName)
     .ToList();

/* group => new
 {
     Department = lstdpt.FirstOrDefault(d => d.DeptName == group.Key)?.DeptName,
     Employees = group.Select(employee => employee.EmpName).ToList()
 })*/


Console.WriteLine("\nEmployees grouped by department:");
foreach (var group in employeesGroupedByDepartment)
{
    Console.WriteLine($"Department: {group.Key}");//Each group has a key
    foreach (var employee in group)//Each group has inner collection
    {
        Console.WriteLine($"  {employee.EmpName}");
    }
}

// 3. Join: Departments with employees working on more than one project
var departmentsWithMultipleProjectEmployees = lstdpt
    .Select(department => new
    {
        Department = department.DeptName,
        Employees = employees
            .Where(employee => employee.Dname == department.DeptName &&
                               assignments.Count(a => a.EmployeeId == employee.Empid) > 1)
            .Select(employee => employee.EmpName)
            .ToList()
    })
    .Where(d => d.Employees.Count > 0)
    .ToList();

Console.WriteLine("\nDepartments with employees working on more than one project:");
foreach (var dept in departmentsWithMultipleProjectEmployees)
{
    Console.WriteLine($"Department: {dept.Department}");
    foreach (var employee in dept.Employees)
    {
        Console.WriteLine($"  {employee}");
    }
}

// 4. Order: Employees sorted by the number of projects they are working on
var employeesSortedByProjects = employees
    .OrderByDescending(employee => assignments.Count(a => a.EmployeeId == employee.Empid))
    .Select(employee => new
    {
        Employee = employee.EmpName,
        ProjectCount = assignments.Count(a => a.EmployeeId == employee.Empid)
    })
    .ToList();

Console.WriteLine("\nEmployees sorted by the number of projects they are working on:");
foreach (var employee in employeesSortedByProjects)
{
    Console.WriteLine($"{employee.Employee} ({employee.ProjectCount} projects)");
}

