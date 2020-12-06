using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class PredefinedTaskMaterialVM
    {
        public string predefinedMaterialId { get; set; }

        public string materialName { get; set; }
        public string materialDescription { get; set; }
        public string materialCost { get; set; }
    }
}
