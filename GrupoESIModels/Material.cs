﻿using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoESIModels.Models
{
    public class Material
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual TaskModel Task { get; set; }

        [ForeignKey("TaskModel")]
        public Guid TaskModelId { get; set; }
    }
}
