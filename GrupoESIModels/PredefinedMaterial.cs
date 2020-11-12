

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoESIModels
{
    public class PredefinedMaterial
    {
        [Key]
        public Guid PredefinedMaterialId { get; set; }
        public Guid PredefinedTaskId { get; set; }
        public PredefinedTask PredefinedTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
