using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhyDelegatesdemo
{
    public delegate bool Delpromote(Employee emp);
    public class Employee
    {     
        public int Id { get; set; }
        public string Name { get; set; }
        public int Experienceinyears { get; set; }
        public decimal Salary { get; set; }

        public static void PromoteEmployee(List<Employee> employees,Delpromote ispromotable)
        {
            foreach (Employee employee in employees)
            {
                if(ispromotable(employee))//Invoking the delegate,execute your promote method
                {
                    Console.WriteLine(employee.Name);
                }
            }
        }

    }
}
