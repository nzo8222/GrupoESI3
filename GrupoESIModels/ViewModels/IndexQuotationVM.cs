using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class IndexQuotationVM
    {
        public PagingInfo pagingInfo { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public DateTime FechaQuotation { get; set; }
    }
}
