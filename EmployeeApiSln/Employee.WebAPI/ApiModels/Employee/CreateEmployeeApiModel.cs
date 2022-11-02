namespace Employee.WebAPI.ApiModels.Employee
{
    public class CreateEmployeeApiModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
