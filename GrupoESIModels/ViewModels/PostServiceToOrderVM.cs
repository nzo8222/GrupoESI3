﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.ViewModels
{
    public class PostServiceToOrderVM
    {
        public Guid orderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public string serviceId { get; set; }
    }
}
