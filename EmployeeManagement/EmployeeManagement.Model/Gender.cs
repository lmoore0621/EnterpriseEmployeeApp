using System.Collections.Generic;

namespace EmployeeManagement.Model
{
    public class Gender : BaseGender
    {
        public List<Employee> Employees { get; set; }
    }
}
