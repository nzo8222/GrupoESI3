using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class MaterialVM
    {
        public Guid OrderDetailsId { get; set; }
        public IList<Material> Material { get; set; }
        public Guid taskId { get; set; }
        public TaskModel tareaLocal { get; set; }
        public MaterialVM()
        {
            Material = new List<Material>();
        }
        public string OrderDetailsStatus { get; set; }
    }
}
