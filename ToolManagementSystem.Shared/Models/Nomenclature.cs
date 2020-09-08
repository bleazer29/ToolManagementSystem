using System;
using System.Collections.Generic;

namespace ToolManagementSystem.Shared.Models
{
    public partial class Nomenclature
    {
        public Nomenclature()
        {
            NomenclatureSpecificationUnit = new HashSet<NomenclatureSpecificationUnit>();
            Tool = new HashSet<Tool>();
        }

        public long NomenclatureId { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public long MaxOperatingTime { get; set; }

        public virtual ICollection<NomenclatureSpecificationUnit> NomenclatureSpecificationUnit { get; set; }
        public virtual ICollection<Tool> Tool { get; set; }
    }
}
