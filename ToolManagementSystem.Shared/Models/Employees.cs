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
        public virtual Users Users { get; set; }
    }
}
