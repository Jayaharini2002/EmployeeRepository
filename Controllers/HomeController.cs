
using Dapper;
using ListEmployees1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Claims;

namespace ListEmployees1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            try
            {
                _logger.LogInformation("Test log");
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, ex);
                throw;
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        string connectionString = "Server=192.168.0.23,1427;Initial Catalog=interns;Integrated Security=False;user id=interns;password=test;Connection Timeout=10";
        string query1 = @"SELECT username,passwd FROM LoginUser";
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(IFormCollection form)
        {

            string name = form["username"];
            string password = form["passwd"];
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var emplist1 = connection.Query<Login>(query1).ToList();
                foreach (var change in emplist1)
                {
                    if (name == change.username && password == change.passwd)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,change.username)
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {

                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties);
                        return RedirectToAction("Index", "Employee");
                    }
                    else
                    {
                        string message = "Invalid Credential";
                        ViewData["message"] = message;
                        return View();

                    }
                }
            }
            return View();
        }
    }
}
