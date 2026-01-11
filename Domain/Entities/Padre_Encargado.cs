using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Padre_Encargado
    {
        [Key]
        public int id_padr { get; set; }
        [Required]
        public string nombre {  get; set; }
        [Required]
        public string apellido { get; set; }
        [EmailAddress]
        public string? email { get; set; }
        public string domicilio { get; set; }
        public int celular {  get; set; }
    }
}
