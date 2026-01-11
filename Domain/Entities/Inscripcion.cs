using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Inscripcion
    {
        [Key]
        public int id_inscripcion { get; set; }
        public int id_alumno { get; set; }
        public int id_grado { get; set; }
        public int año_electivo { get; set; }
        public DateTime fecha_inscripcion { get; set; }
    }
}
