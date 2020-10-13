using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class ServiceAndProviderVM
    {
        public ApplicationUser UserObj { get; set; }
        public List<Service> Services { get; set; }
        public string UserLocalId { get; set; }
        //public IEnumerable<ServiceModel> Services { get; set; }
    }
}
