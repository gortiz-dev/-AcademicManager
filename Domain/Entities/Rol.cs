using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Rol
    {
        [Key]
        public int id_rol {  get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
