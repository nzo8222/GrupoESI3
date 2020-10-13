﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESIModels.Models
{
    public class Service
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Guid ServiceTypeId { get; set; }
        [ForeignKey("ServiceTypeId")]
        public ServiceType serviceType { get; set; }
        


        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
