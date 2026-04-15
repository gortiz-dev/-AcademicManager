using AcademicManager.Domain.Interfaces;
using AcademicManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
namespace AcademicManager.API.Controllers
{
    [ApiController]
    [Route("api/Usuarios")]
    public class AlumnoPadreController : ControllerBase
    {
        private readonly IAlumno_padreRepository _alumno_padreRepository;

        public AlumnoPadreController(IAlumno_padreRepository alumno_padreRepository)
        {
            _alumno_padreRepository = alumno_padreRepository;
        }
        private int GetCurrentUserId() => 1;

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var alumno_apdre = await _alumno_padreRepository.GetByIdAsync(id);
            if (alumno_apdre == null)
                return NotFound("Enacargano no necontrado");
            return Ok(alumno_apdre);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Alumno_padre alumno_Padre)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id_generado = await _alumno_padreRepository.InsertAsync(alumno_Padre, GetCurrentUserId());
            return CreatedAtAction(nameof(GetById), new { id = id_generado }, alumno_Padre);
        }

        [HttpPut("{id:int}")]

        public async Task<IActionResult> Update(int id, [FromBody] Alumno_padre alumno_Padre)
        {
            if (id != alumno_Padre.id_alumno_padre) return BadRequest("El id no coincide");
            await _alumno_padreRepository.UpdateAsync(alumno_Padre, GetCurrentUserId());
            return NoContent();
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            await _alumno_padreRepository.DeleteAsync(id, GetCurrentUserId());
            return NoContent();
        }

    }
}
