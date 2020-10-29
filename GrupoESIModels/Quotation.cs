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
        [ForeignKey("OrderDetailsId")]
        public OrderDetails OrderDetails { get; set; }
        public Guid OrderDetailsId { get; set; }
        public virtual List<TaskModel> Tasks { get; set; }
        public DateTime ProviderArrivalDate { get; set; }
        public DateTime QuotationSaveDate { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual EmployeeUser Employee { get; set; }
        public string EmployeeId { get; set; }
    }
}
