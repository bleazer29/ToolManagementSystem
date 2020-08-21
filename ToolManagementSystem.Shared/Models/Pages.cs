using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToolManagementSystem.Shared.Models
{
    public class Pages
    {
        public int Id { get; set; }
        public string NamePage { get; set; }

        [NotMapped]
        public IList<RolesPages> RolesPages { get; set; }
    }
}
