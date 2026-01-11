using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int id_curso { get; set; }
        [Required]
        public string nombre { get; set; }
        public int id_grado { get; set; }
       
        public int id_docente { get; set; }
    }
}
