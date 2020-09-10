using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Specification
    {
        public Specification()
        {
            NomenclatureSpecificationUnit = new HashSet<NomenclatureSpecificationUnit>();
        }

        public int SpecificationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NomenclatureSpecificationUnit> NomenclatureSpecificationUnit { get; set; }
    }
}
