using System.Net;

namespace Employee.WebAPI.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
