using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Question { get; set; } = "Who are you?";
        [Required]
        public string Answer { get; set; } = "Admin";

        [NotMapped]
        public IList<EmployeeRoles> EmployeeRoles { get; }

    }
}
