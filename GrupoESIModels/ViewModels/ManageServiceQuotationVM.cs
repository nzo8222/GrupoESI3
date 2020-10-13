using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class ManageServiceQuotationVM
    {
        public Service ServiceModel { get; set; }
        public bool sendQuotation { get; set; }
    }
}
