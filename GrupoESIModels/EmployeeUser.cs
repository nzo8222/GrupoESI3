using Microsoft.AspNetCore.Identity;

using System.Collections.Generic;

namespace GrupoESIModels.Models
{
    public class EmployeeUser : IdentityUser
    {
        public string Name { get; set; }
        public ApplicationUser EmployedBy { get; set; }
        public List<Service> ServiceLst { get; set; }

        public EmployeeUser()
        {
            ServiceLst = new List<Service>();
        }
    }
}
