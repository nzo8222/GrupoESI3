using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class CreatePredefinedTaskVM
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string PredefinedTaskName { get; set; }
        public string PredefinedTaskDescription { get; set; }
        public int PredefinedTaskDuration { get; set; }
        public double CostHandLabor { get; set; }
        public double Cost { get; set; }
        public string TaskDescription { get; set; }
        public Guid serviceId { get; set; }
    }
}
