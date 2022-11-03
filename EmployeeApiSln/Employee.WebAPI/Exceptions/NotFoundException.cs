using System.Net;

namespace Employee.WebAPI.Exceptions
{
    public class NotFoundException : ApiException
    {
        public NotFoundException() : base(HttpStatusCode.NotFound) { }
    }
}
