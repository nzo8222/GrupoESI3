using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class OrderAndOrderDetailsVM
    {
        public Order OrderModel { get; set; }
        public OrderDetails OrderDetailsModel { get; set; }
        public Guid serviceIdVM { get; set; }
    }
}
