using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Specification
    {
        public Specification()
        {
            SpecificationUnit = new HashSet<SpecificationUnit>();
        }

        public long SpecificationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpecificationUnit> SpecificationUnit { get; set; }
    }
}
