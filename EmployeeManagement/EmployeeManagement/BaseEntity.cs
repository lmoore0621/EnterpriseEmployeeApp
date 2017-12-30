
namespace EmployeeManagement
{
    public class BaseEntity<TEntityId>
    {
        public TEntityId Id { get; set; }
    }

    public class BaseEntity : BaseEntity<int>
    {

    }
}
