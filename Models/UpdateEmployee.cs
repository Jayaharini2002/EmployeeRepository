using System.ComponentModel.DataAnnotations;

namespace ListEmployees1.Models
{
    public class UpdateEmployee
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string DeptName { get; set; }
    }
}
