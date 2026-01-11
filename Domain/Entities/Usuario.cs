using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademicManager.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string usuario { get; set; } = string.Empty;

        [Required]
        [StringLength(255)] // Las contraseñas suelen ser largas si usas Hash
        public string password { get; set; } = string.Empty;

        [Required]
        public int id_rol { get; set; }

        [StringLength(20)]
        public string estado { get; set; } = "Activo"; // Valor por defecto
    }
}