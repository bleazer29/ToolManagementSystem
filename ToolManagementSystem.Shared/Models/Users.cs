using System.ComponentModel.DataAnnotations;

namespace ToolManagementSystem.Shared.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^\+[1-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Номер телефона должен иметь формат +xxx-xxx-xxxx")]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

    }
}
