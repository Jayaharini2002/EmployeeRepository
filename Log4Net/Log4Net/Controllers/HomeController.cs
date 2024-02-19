using log4net;
using Log4Net.Models;
using Log4NetDemo;
using Log4NetDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Log4Net.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _logger;
        private readonly IEmployeeInfo _empinfo;
        public HomeController(ILog logger,IEmployeeInfo empinfo)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _empinfo = empinfo;
        
        }

        public IActionResult Index()
        {
            string Name=_empinfo.GetEmployeeName();
            var emplist = _empinfo.GetEmployeeDetails();
            
            
            return View(emplist);
        }
        [HttpGet]
        public IActionResult Get()
        {
            Console.WriteLine("Executing Log4Net ");
            _logger.Info("Hello logging world!");
            _logger.Info("This is an informational log.");
            _logger.Error("This is an error log.");
            return Ok("Test success!");
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
    
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string Login(string AccountNumber, string Pin)
        {
            // Process the data
            // ...
            return $"AccountNumber: {AccountNumber} Pin Changed to: {Pin}";
        }
    }
}
