using GrupoESIModels.Enums;

using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GrupoESIModels.Models
{
    public class Picture
    {
        [Key]
        public Guid PictureId { get; set; }
        public byte[] PictureBytes { get; set; }

        [ForeignKey("TaskModel")]
        public Guid TaskModelId { get; set; }

        public PictureTypeEnum Tipo { get; set; }
        public DateTime FechaDeSubida { get; set; }
    }
}
