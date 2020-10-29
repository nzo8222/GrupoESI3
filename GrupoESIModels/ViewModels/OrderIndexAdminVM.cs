using GrupoESIModels.GrupoESIModels;
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class OrderIndexAdminVM
    {
        public List<Order> OrderList { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
