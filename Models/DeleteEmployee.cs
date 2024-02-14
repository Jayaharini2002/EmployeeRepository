using System.ComponentModel.DataAnnotations;

namespace ListEmployees1.Models
{
    public class DeleteEmployee
    {
        [Required]
        [Key]
        [Range(1, 100)]
        public int Id { get; set; }
    }
}
