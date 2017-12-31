using System.Collections.Generic;

namespace EmployeeManagement.DTOs
{
    public class StateDto : BaseState
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
