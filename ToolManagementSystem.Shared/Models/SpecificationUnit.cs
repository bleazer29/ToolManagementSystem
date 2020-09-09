using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class SpecificationUnit
    {
        public SpecificationUnit()
        {
            NomenclatureSpecificationUnit = new HashSet<NomenclatureSpecificationUnit>();
        }

        public long SpecificationUnitId { get; set; }
        public long UnitId { get; set; }
        public long SpecificationId { get; set; }

        public virtual Specification Specification { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<NomenclatureSpecificationUnit> NomenclatureSpecificationUnit { get; set; }
    }
}
