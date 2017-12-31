
namespace EmployeeManagement.Service
{
    public class Request
    {
        public bool PageItems { get; set; }

        public int ItemCount { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }

        public int MedianPage { get; set; }

        public int? Skip
        {
            get
            {
                int? skip = null;

                if (PageItems && PageSize.HasValue && PageNumber.HasValue)
                {
                    skip = ((PageNumber - 1) * PageSize);
                }

                return skip;
            }
        }

        public int? Take
        {
            get
            {
                int? take = null;

                if (PageItems && PageSize.HasValue)
                {
                    take = PageSize;
                }

                return take;
            }
        }
    }
}
