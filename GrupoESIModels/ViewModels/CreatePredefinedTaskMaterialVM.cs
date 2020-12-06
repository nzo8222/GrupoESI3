using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class CreatePredefinedTaskMaterialVM
    {
        //[DisplayName("Nombre de servicio")]
        //public string serviceName { get; set; }
        //[DisplayName("Descripción de servicio")]
        //public string serviceDescription { get; set; }
        //[DisplayName("Nombre de tarea predefinida")]
        //public string predefinedTaskName { get; set; }
        //[DisplayName("Descripción tarea predefinida")]
        //public string predefinedTaskDescription { get; set; }
        //[DisplayName("Costo tarea predefinida")]
        //public double predefinedTaskCost { get; set; }
        [DisplayName("Nombre del material")]
        [RegularExpression(@"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")]

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string predefinedTaskMaterialName { get; set; }
        [RegularExpression(@"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        [DisplayName("Descripción del material")]
        public string predefinedTaskMaterialDescription{ get; set; }
        [DisplayName("Costo del material")]
        public double predefinedTaskMaterialCost { get; set; }
        public Guid predefinedTaskId { get; set; }
        public Guid predefinedMaterialId { get; set; }

    }
}
