using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Unit
    {
        public Unit()
        {
            NomenclatureSpecificationUnit = new HashSet<NomenclatureSpecificationUnit>();
        }

        public int UnitId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<NomenclatureSpecificationUnit> NomenclatureSpecificationUnit { get; set; }
    }
}
