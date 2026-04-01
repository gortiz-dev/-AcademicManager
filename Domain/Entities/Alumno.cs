using AcademicManager.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Alumno
    {
        [Key]
        public int id_alumno { get; set; }

        [Required]
        public string nombre { get; set; } = null!;

        [Required]
        public string apellido { get; set; } = null!;

        [Required]
        public string email { get; set; } = null!;

        public string? domicilio { get; set; }

        public int celular { get; set; }

        public EstadoGeneral estado { get; set; }
    }
}
