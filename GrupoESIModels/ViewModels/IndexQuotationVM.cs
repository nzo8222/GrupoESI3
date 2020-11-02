using GrupoESIModels.GrupoESIModels;
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;


namespace GrupoESIModels.ViewModels
{
    public class IndexQuotationVM
    {
        public PagingInfo pagingInfo { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public DateTime FechaQuotation { get; set; }
        public string ProvideerId { get; set; }
    }

       

}
