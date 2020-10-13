using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class ServiceTypeVM
    {
        public List<ServiceType> ServiceTypeList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
