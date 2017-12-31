
namespace EmployeeManagement.DTOs
{
    public class EmployeeDto : BaseEmployee
    {
        public DegreeDto Degree { get; set; }

        public GenderDto Gender { get; set; }

        private StateDto State { get; set; }
    }
}
