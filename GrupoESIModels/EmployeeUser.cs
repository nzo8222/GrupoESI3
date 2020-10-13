using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class EmployeeUser : IdentityUser
    {
        public string Name { get; set; }
        public ApplicationUser EmployedBy { get; set; }
        public List<Service> ServiceLst { get; set; }
        public List<Quotation> QuotationLst { get; set; }
        public EmployeeUser()
        {
            ServiceLst = new List<Service>();
            QuotationLst = new List<Quotation>();
        }
    }
}
