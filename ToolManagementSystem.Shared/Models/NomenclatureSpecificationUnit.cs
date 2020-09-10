using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class NomenclatureSpecificationUnit
    {
        public int NomenclatureSpecificationUnitId { get; set; }
        public int NomenclatureId { get; set; }
        public double Value { get; set; }
        public int SpecificationId { get; set; }
        public int UnitId { get; set; }

        public virtual Nomenclature Nomenclature { get; set; }
        public virtual Specification Specification { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
