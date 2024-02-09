
using System.ComponentModel.DataAnnotations;
namespace ListEmployees1.Models
{
    public class Login 
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string passwd { get; set; }
        public string TableAccessName {  get; set; }
    }
}
