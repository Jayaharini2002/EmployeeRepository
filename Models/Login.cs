
using System.ComponentModel.DataAnnotations;
namespace ListEmployees1.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter name")]
        public required string username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public required string passwd { get; set; }
        
    }
}
