using System;
using System.Collections.Generic;
using System.Text;

namespace ToolManagementSystem.Shared.RequestModels
{
    public class OperatingTimeRequest
    {
        public long OperatingTime { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
