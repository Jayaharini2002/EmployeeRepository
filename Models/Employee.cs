using System.ComponentModel.DataAnnotations;
namespace ListEmployees1.Models
{
    public class Employee
    {
        [Required]
        [Key]
        [Range(1, 100)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string DeptName { get; set; }

        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime dob { get; set; }
        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal Tax { get; set; }
        public decimal Allowances { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

