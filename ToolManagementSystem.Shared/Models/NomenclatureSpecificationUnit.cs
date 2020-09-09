using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class NomenclatureSpecificationUnit
    {
        public long NomenclatureSpecificationUnitId { get; set; }
        public long NomenclatureId { get; set; }
        public long SpecificationUnitId { get; set; }
        public double Value { get; set; }

        public virtual Nomenclature Nomenclature { get; set; }
        public virtual SpecificationUnit SpecificationUnit { get; set; }
    }
}
