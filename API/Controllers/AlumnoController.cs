using AcademicManager.Domain.Entities;
using AcademicManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManager.API.Controllers
{
    [ApiController]
    [Route("api/alumnos")]
    public class AlumnoController : ControllerBase
    {
        private readonly IAlumnoRepository _alumnoRepository;

        public AlumnoController(IAlumnoRepository alumnoRepository)
        {
            _alumnoRepository = alumnoRepository;
        }

        // Simulación de usuario logueado (En el futuro esto vendrá del Token JWT)
        // Por ahora lo pedimos en el Header o usamos uno fijo para las pruebas
        private int GetCurrentUserId() => 1;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alumno = await _alumnoRepository.GetByIdAsync(id);
            if (alumno == null) return NotFound("Alumno no encontrado");
            return Ok(alumno);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Alumno alumno)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Pasamos el ID del usuario que está creando el registro
            var idGenerado = await _alumnoRepository.InsertAsync(alumno, GetCurrentUserId());

            return CreatedAtAction(nameof(GetById), new { id = idGenerado }, alumno);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.id_alumno) return BadRequest("El ID no coincide");

            // Pasamos el ID del usuario que está actualizando
            await _alumnoRepository.UpdateAsync(alumno, GetCurrentUserId());
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Pasamos el ID del usuario que está eliminando (borrado lógico)
            await _alumnoRepository.DeleteAsync(id, GetCurrentUserId());
            return NoContent();
        }
    }
}