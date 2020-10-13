using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class TaskMaterialVM
    {
        public TaskModel TareaModel { get; set; }
        public Material MaterialModel { get; set; }
        public Guid taskId { get; set; }
        public Guid orderDetailsId { get; set; }
        public TaskMaterialVM()
        {

        }
    }
}
