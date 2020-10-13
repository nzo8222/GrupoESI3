using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class Quotation
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public OrderDetails OrderDetailsModel { get; set; }
        [ForeignKey("OrderDetailsModelId")]
        public Guid OrderDetailsId { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
        public DateTime FechaLlegadaProveedor { get; set; }
        public DateTime FechaGuardadoCotizacion { get; set; }

    }
}
