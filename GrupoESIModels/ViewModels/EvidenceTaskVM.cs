using GrupoESIModels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class EvidenceTaskVM
    {
        public TaskModel task { get; set; }

        public IFormFile Upload { get; set; }
        
    }
}
