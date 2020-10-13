using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class AddServiceVM
    {
        public Guid orderDetailsId { get; set; }
        public Guid serviceId { get; set; }
        public Guid OrderId { get; set; }
        public OrderDetails OrderDetailsLocal { get; set; }
        public List<Service> lstServicios { get; set; }
        public List<OrderDetails> OrderDetailsList { get; set; }

        public AddServiceVM(Guid orderDetails)
        {
            orderDetailsId = orderDetails;
            lstServicios = new List<Service>();
            OrderDetailsList = new List<OrderDetails>();
        }
        public AddServiceVM()
        {

        }
    }
}
