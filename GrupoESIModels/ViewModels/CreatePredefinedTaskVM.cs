using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrupoESIModels.ViewModels
{
    public class CreatePredefinedTaskVM
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        [Display(Name = "Nombre de tarea predefinida")]
        [RegularExpression(@"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string PredefinedTaskName { get; set; }
        [Display(Name = "Descripción de tarea predefinida")]
        [RegularExpression(@"(?i)^(?:(?![×Þß÷þø])[-'0-9a-zÀ-ÿ])+$")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string PredefinedTaskDescription { get; set; }
        [Display(Name = "Duracion tarea predefinida")]
        
        public int PredefinedTaskDuration { get; set; }
        [Required]
        public double CostHandLabor { get; set; }
        

        public Guid serviceId { get; set; }
    }
}
