using GrupoESIModels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class TaskPictureVM
    {
        public TaskModel taskModel { get; set; }
        public string OrderDetailsStatus { get; set; }

        public IFormFile Upload { get; set; }
        public TaskPictureVM()
        {
            taskModel = new TaskModel();
        }
    }
}
