using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Grado
    {
        [Key]
        public int id_grado { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string nivel { get; set; }
    }
}
