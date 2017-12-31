using System.Collections.Generic;

namespace EmployeeManagement.Service
{
    public class Response
    {
        public Response()
        {
            Details = new Dictionary<string, object>();
        }

        public Response(Response response)
        {
            Successful = response.Successful;
            Message = response.Message;
            PagingInfo = response.PagingInfo;
            Details = response.Details;
        }

        public bool Successful { get; set; }

        public string Message { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public Dictionary<string, object> Details { get; set; }
    }
}
