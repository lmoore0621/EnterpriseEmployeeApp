using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public class Degree : BaseDegree
    {
        public List<Employee> Employees { get; set; }
    }
}
