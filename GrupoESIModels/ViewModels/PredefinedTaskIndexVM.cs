using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class PredefinedTaskIndexVM
    {
        public string serviceId { get; set; }
        public string predefinedTaskId { get; set; }
        public string predefinedTaskName { get; set; }
        public string predefinedTaskDescription { get; set; }
        public string predefinedTaskDuration { get; set; }
        public string predefinedTaskCost { get; set; }
        public string predefinedTaskCostHandLabor { get; set; }
    }
}
