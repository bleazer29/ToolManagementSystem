using System;
using System.Collections.Generic;
using System.Text;

namespace ToolManagementSystem.Shared.RequestModels.NRI
{
    public class CounterpartyFilterRequest
    {
        public string Name { get; set; }
        public string EDRPOU { get; set; }
    }
}
