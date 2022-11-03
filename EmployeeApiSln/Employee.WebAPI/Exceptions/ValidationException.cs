using Microsoft.AspNetCore.Mvc;

namespace Employee.WebAPI.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Errors { get; private set; }

        public ValidationException(IDictionary<string, string[]> errors)
        {
            Errors = errors;
        }

        public ValidationProblemDetails ProblemDetails
        {
            get
            {
                if (Errors != null)
                {
                    return new ValidationProblemDetails(Errors);
                }

                return new ValidationProblemDetails(new Dictionary<string, string[]>
                    { { "Error", new[] { Message } } });
            }
        }
    }
}
