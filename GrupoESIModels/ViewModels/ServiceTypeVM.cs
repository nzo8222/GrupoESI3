using GrupoESIModels.GrupoESIModels;
using GrupoESIModels.Models;
using System.Collections.Generic;


namespace GrupoESIModels.ViewModels
{
    public class ServiceTypeVM
    {
        public List<ServiceType> ServiceTypeList { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
