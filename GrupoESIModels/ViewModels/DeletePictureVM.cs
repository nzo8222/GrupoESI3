﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class DeletePictureVM
    {
        public string deletePicturesId { get; set; }
        public Guid taskId { get; set; }
        public Guid orderDetailsId { get; set; }
    }
}
