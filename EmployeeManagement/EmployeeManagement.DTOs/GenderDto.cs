using System.Collections.Generic;

namespace EmployeeManagement.DTOs
{
    public class GenderDto : BaseGender
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
