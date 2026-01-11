using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AcademicManager.Domain.Entities
{
    public class Alumno
    {
        [Key]
        public  string id_alumno {  get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }
        public string? domicilio { get; set; }
        public int  celular {  get; set; }
        public string? estado { get; set; }
    }
}
