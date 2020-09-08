using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Unit
    {
        public Unit()
        {
            SpecificationUnit = new HashSet<SpecificationUnit>();
        }

        public long UnitId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SpecificationUnit> SpecificationUnit { get; set; }
    }
}
