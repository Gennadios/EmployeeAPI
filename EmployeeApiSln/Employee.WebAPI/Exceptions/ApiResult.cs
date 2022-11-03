namespace Employee.WebAPI.Exceptions
{
    public static class ApiResult
    {
        public static Exception NotFound() => new NotFoundException();
        public static Exception ValidationUpdateId() 
            => Validation("Id", "'Id' in data and 'Id' in request should be equal.");

        private static Exception Validation(string field, string message) 
            => new ValidationException(new Dictionary<string, string[]> { { field, new[] { message } } });
    }
}
