using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Nota
    {
        [Key]
        public int id_nota { get; set; }
        public int id_detalle_inscripcion { get; set; }
        public int id_periodo_academico { get; set; }
        public int calificasion {  get; set; }
    }
}
