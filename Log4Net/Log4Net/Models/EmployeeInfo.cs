namespace Log4NetDemo.Models
{
    public class EmployeeInfo : IEmployeeInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string GetEmployeeName()
        {
            string Name = "Gayu";
            return Name;
        }
        public List<EmployeeInfo> GetEmployeeDetails()
        {
            List<EmployeeInfo> emplist = new List<EmployeeInfo>();
            emplist.Add(new EmployeeInfo { Id = 11, Name = "Rajee" });
            emplist.Add(new EmployeeInfo { Id = 22, Name = "Logha" });
            emplist.Add(new EmployeeInfo { Id = 33, Name = "Ram" });
            emplist.Add(new EmployeeInfo { Id = 44, Name = "Harini" });
            return emplist;
        }
    }
}
