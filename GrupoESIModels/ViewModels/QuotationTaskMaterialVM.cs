using GrupoESIModels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class QuotationTaskMaterialVM
    {
        public Quotation QuotationModel { get; set; }


        public Guid orderDetailsId { get; set; }
        public List<OrderDetails> lstOrderDetailsSameUserServices { get; set; }


        public List<EmployeeUser> lstEmployees { get; set; }

        public QuotationTaskMaterialVM()
        {
            lstEmployees = new List<EmployeeUser>();
            lstOrderDetailsSameUserServices = new List<OrderDetails>();
        }
        
    }
}
