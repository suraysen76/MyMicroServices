namespace MicroserviceWeb.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpNo { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
    }
}
