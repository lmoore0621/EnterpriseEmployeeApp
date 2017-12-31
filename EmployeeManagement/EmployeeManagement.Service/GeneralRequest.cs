
namespace EmployeeManagement.Service
{
    public enum GeneralRequestType
    {
        GetStateOptions,
        GetDegreeOptions,
        GetGenderOptions
    }

    public class GeneralRequest : Request
    {
        public GeneralRequest(GeneralRequestType requestType)
        {
            Type = requestType;
        }

        public GeneralRequestType Type { get; set; }
    }
}
