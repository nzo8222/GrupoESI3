using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class OrderDetails
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public virtual Quotation Quotation { get; set; }
        public string Status { get; set; }
        public double Cost { get; set; }
        public OrderDetails()
        {
            Service = new Service();
            Order = new Order();
        }
    }
}
