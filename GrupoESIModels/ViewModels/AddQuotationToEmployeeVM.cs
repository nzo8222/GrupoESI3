using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class AddQuotationToEmployeeVM
    {
        public IList<EmployeeUser> EmployeeUsrLst { get; set; }
        public Guid QuotationIdLocal { get; set; }
        public Guid OrderDetailsId { get; set; }
        public AddQuotationToEmployeeVM()
        {
            EmployeeUsrLst = new List<EmployeeUser>();
        }
    }
}
