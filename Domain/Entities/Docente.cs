using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Docente
    {
        [Key]
        public int id_docente { get; set; }

        [Required] 
        public string nombre { get; set; }

        public string apellido { get; set; } 

        [EmailAddress] 
        public string? email { get; set; }

        public string domicilio { get; set; }

        public int celular { get; set; } 
    }
}