using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Detalle_inscripcion
    {

        [Key]
        public int id_detalle_incripcion { get; set; }
        
        public int id_inscripcion { get; set; }
        
        public int id_curso { get; set; }

    }
}
