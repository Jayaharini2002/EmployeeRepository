using Dapper;
using ListEmployees1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Data;
using System.Data.SqlClient;
namespace ListEmployees1.Controllers
{
    
    public class EmployeeController : Controller
    {

        string connectionString = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=interns;password=test;Connection Timeout=10";
        string query1 = @"SELECT * FROM EmployeeList";
        string query2 = "INSERT INTO EmployeeList(Name, DeptName,Salary,IsActive,dob,Basic,HRA,Tax,Allowances,Address) VALUES ( @Name, @DeptName,@Salary,@IsActive,@dob,@Basic,@HRA,@Tax,@Allowances,@Address)";
        [AllowAnonymous]
        [ResponseCache(Duration = 100)]
        [Route("All")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Select()
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {

                var emplist = await conn.QueryAsync<Employee>(query1);
                return View(emplist);
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult FilterDetails()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        [Route("Employee/FilterDetails/employee")]
        public IActionResult FilterDetails(Employee employee)
        {
            int id = Convert.ToInt32(employee.Id);
            string connectionString = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=interns;password=test;Connection Timeout=10";
            using (IDbConnection conn = new SqlConnection(connectionString))
            {

                var emplist1 = conn.Query<Employee>("Select * from EmployeeList where id=@id", new { Id = id }).ToList();
                foreach (var change in emplist1)
                {
                    ViewBag.Id = change.Id;
                    ViewBag.Name = change.Name;
                    ViewBag.DeptName = change.DeptName;
                    ViewBag.dob = change.dob;
                    ViewBag.Address = change.Address;
                }

                return View();
            }
        }
        [HttpGet]
        public IActionResult InsertEmployeeDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult InsertEmployeeDetails(Employee employee)
        {
            string name = employee.Name;
            string dname = employee.DeptName;
            decimal salary = Convert.ToDecimal(employee.Salary);
            bool active = Convert.ToBoolean(employee.IsActive);
            DateTime dob1 = Convert.ToDateTime(employee.dob);
            decimal basic = Convert.ToDecimal(employee.Basic);
            decimal hra = Convert.ToDecimal(employee.HRA);
            decimal tax = Convert.ToDecimal(employee.Tax);
            decimal allowances = Convert.ToDecimal(employee.Allowances);
            string address = employee.Address;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                connection.Execute(query2, new { Name = name, DeptName = dname, Salary = salary, IsActive = active, dob = dob1, Basic = basic, HRA = hra, Tax = tax, Allowances = allowances, Address = address });

                return View();
            }
        }
        [HttpGet]
        public IActionResult UpdateEmployeeDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult UpdateEmployeeDetails(Employee employee)
        {
            string name = employee.Name;
            string dname = employee.DeptName;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                connection.Execute("Update EmployeeList set DeptName=@DeptName where Name = @Name", new { Name = name, DeptName = dname });

                return View();
            }
        }
        [HttpGet]
        public IActionResult DeleteEmployeeDetails()
        {
            return View();
        }


        [HttpPost]
        public IActionResult DeleteEmployeeDetails(Employee employee)
        {
            int id = Convert.ToInt32(employee.Id);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                connection.Execute("Delete from EmployeeList where Id = @Id", new { Id = id });

                return View();
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout(Login lg)
        {
            if (lg.username == "Yes" || lg.username == "yes" || lg.username == "y")
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Select", "Employee");
            }
        }


    }
}
