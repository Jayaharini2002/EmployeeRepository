namespace Log4NetDemo.Models
{
    public class Employee:IEmployeeInfo
    {
        
        public string GetEmployeeName()
        {
            string Name = "Harini";
            return Name;
        }
        public List<EmployeeInfo> GetEmployeeDetails()
        {
            List<EmployeeInfo> emplist=new List<EmployeeInfo>();
            emplist.Add(new EmployeeInfo { Id = 1, Name = "Raje" });
            emplist.Add(new EmployeeInfo { Id = 2, Name = "Logha" });
            emplist.Add(new EmployeeInfo { Id = 3, Name = "Ram" });
            emplist.Add(new EmployeeInfo { Id = 4, Name = "Harini" });
            return emplist;
        }
    }
}
