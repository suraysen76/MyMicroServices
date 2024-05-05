namespace MicroserviceWeb.Models
{
    public class CompanyEmployees
    {
        public int Id { get; set; }

        public string EmpNo { get; set; }
        public string EmployeeName { get; set; }
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }

    }
}
