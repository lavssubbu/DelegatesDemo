// See https://aka.ms/new-console-template for more information
using WhyDelegatesdemo;

Console.WriteLine("Hello, World!");


List<Employee> employees = new List<Employee>()
{
    new Employee(){Id=1,Name="Riya",Experienceinyears=5,Salary=80000},
    new Employee(){Id=2,Name="Liya",Experienceinyears=6,Salary=85000},
    new Employee(){Id=3,Name="Riyaz",Experienceinyears=7,Salary=90000},
    new Employee(){Id=4,Name="Reethu",Experienceinyears=5,Salary=80000},
    new Employee(){Id=5,Name="Megha",Experienceinyears=4,Salary=70000},
};
//create instance for delegate
Delpromote delpromotable = new Delpromote(Promote);

Employee.PromoteEmployee(employees,delpromotable);

static bool Promote(Employee employee)
{
    if (employee.Salary > 70000)
    {
        return true;
    }
    return false;
}