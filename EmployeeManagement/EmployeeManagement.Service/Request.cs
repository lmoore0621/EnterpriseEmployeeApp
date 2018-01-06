
using System;

namespace EmployeeManagement.Service
{
    public class Request
    {
        public bool PageItems { get { return PageNumber.HasValue && PageSize.HasValue; } }

        public int ItemCount { get; set; }

        public int? PageSize { get; set; }

        public int? PageNumber { get; set; }

        public int MedianPage { get; set; }

        public int? Skip
        {
            get
            {
                int? skip = null;

                if (PageItems)
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
