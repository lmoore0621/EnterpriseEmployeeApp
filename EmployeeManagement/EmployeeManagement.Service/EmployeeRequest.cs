using EmployeeManagement.DTOs;

namespace EmployeeManagement.Service
{
    public enum EmployeeRequestType
    {
        CreateEmployee,
        GetAllEmployees,
        GetEmployee,
        UpdateEmployee,
        DeleteEmployee
    }

    public class EmployeeRequest : Request
    {
        public EmployeeRequest(EmployeeRequestType requestType)
        {
            Type = requestType;
        }

        public EmployeeRequestType Type { get; set; }

        public EmployeeDto Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}
