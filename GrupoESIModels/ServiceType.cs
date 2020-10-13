using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class ServiceType
    {
        [Key]
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Descripcion { get; set; }
    }
}
