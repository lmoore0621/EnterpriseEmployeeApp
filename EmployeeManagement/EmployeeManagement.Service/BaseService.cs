using System;

namespace EmployeeManagement.Service
{
    public class BaseService
    {
        protected PagingInfo GetPagingInfo(Request request, int itemCount)
        {
            PagingInfo pi = null;

            if (request.PageItems)
            {
                pi = new PagingInfo(itemCount, request.PageNumber.Value, request.PageSize.Value, request.MedianPage);
            }

            return pi;
        }

        protected void GetExceptionInfo(Exception ex, Response response, string defaultMsg)
        {
                response.Successful = false;
                response.Message = defaultMsg;

                response.Details.Add("Level 1 Message", ex.Message);
                response.Details.Add("Level 1 Stack Trace", ex.StackTrace);

                int counter = 2;

                Exception iEx = ex.InnerException;
                while (iEx != null)
                {
                    response.Details.Add("Level " + counter.ToString() + " Message", iEx.Message);
                    response.Details.Add("Level " + counter.ToString() + " Stack Trace", iEx.StackTrace);
                    iEx = iEx.InnerException;
                    counter++;
                }
        }
    }
}
