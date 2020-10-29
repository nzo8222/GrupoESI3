using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class TaskModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public double Cost { get; set; }
        public double CostHandLabor { get; set; }
        public virtual List<Material> ListMaterial { get; set; }
        [ForeignKey("QuotationId")]
        public Quotation QuotationModel { get; set; }
        public virtual List<Picture> Pictures { get; set; }
        public Guid QuotationId { get; set; }

    }
}
