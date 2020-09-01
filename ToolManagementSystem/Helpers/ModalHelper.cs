using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolManagementSystem.Client.Helpers
{
    public class ModalHelper
    {
        public ModalHelper()
        {
            
        }

        [JSInvokable]
        public Pages.NRI.ClassificationEditModal CreateModalHelper() {
            return new Pages.NRI.ClassificationEditModal();
        }
    }
}
