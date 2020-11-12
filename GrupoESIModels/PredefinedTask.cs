

using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoESIModels
{
    public class PredefinedTask
    {
        [Key]
        public Guid PredefinedTaskId { get; set; }
        public virtual Service Service { get; set; }
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
        public double CostHandLabor { get; set; }
        public virtual List<PredefinedMaterial> ListPredefinedMaterial { get; set; }
    }
}
