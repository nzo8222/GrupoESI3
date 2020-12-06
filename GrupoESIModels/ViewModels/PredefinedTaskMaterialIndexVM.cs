using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class PredefinedTaskMaterialIndexVM
    {
        [DisplayName("Nombre de servicio")]
        public string  serviceName { get; set; }
        [DisplayName("Descripción de servicio")]
        public string serviceDescription { get; set; }
        [DisplayName("Nombre de tarea predefinida")]
        public string predefinedTaskName { get; set; }
        [DisplayName("Descripción tarea predefinida")]
        public string predefinedTaskDescription { get; set; }
        [DisplayName("Costo tarea predefinida")]
        public double predefinedTaskCost { get; set; }
        public Guid predefinedTaskId { get; set; }
        public Guid serviceId { get; set; }
    }
}
