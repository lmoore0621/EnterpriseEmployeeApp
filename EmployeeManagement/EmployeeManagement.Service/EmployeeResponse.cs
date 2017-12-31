using System.Collections.Generic;
using EmployeeManagement.DTOs;

namespace EmployeeManagement.Service
{
    public class EmployeeResponse : Response
    {
        public EmployeeDto Employee { get; set; }

        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}
