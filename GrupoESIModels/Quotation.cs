using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoESIModels.Models
{
    public class Quotation
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public OrderDetails OrderDetailsModel { get; set; }
        [ForeignKey("OrderDetails")]
        public Guid OrderDetailsId { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
        public DateTime ProviderArrivalDate { get; set; }
        public DateTime QuotationSaveDate { get; set; }

    }
}
