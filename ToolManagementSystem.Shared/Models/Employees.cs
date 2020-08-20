using System;
using System.ComponentModel.DataAnnotations;

namespace ToolManagementSystem.Shared.Models
{
    public class Employees
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string FullName { get { return LastName + " " + FirstName + " " + Patronymic; } }
        [DataType(DataType.Date), Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        [RegularExpression(@"^\+[1-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +xxx-xxx-xxxx")]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

    }
}
