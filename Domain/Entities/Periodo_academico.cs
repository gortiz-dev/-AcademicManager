using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Periodo_academico
    {
        [Key]
        public int id_periodo_academico { get; set; }
        [Required]
        public string nombre { get; set; }
    }
}
