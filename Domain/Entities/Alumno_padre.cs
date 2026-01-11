using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Alumno_padre
    {
        [Key]
        public int id_alumno_padre { get; set; }
        public int id_alumno { get; set; }
        public int id_padre { get; set; }
        public string tipo_relacion {  get; set; }

    }
}
