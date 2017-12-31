using System.Collections.Generic;

namespace EmployeeManagement.DTOs
{
    public class DegreeDto : BaseDegree
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
