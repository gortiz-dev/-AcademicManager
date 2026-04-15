using AcademicManager.Domain.Entities;
using AcademicManager.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademicManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class UsuarioController : ControllerBase 
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        private int GetCurrentUserId() => 1; // Placeholder para el ID del usuario actual

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var resultado = await _usuarioRepository.GetByIdAsync(id);
            if (resultado == null)
                return NotFound("Usuario no encontrado");

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Pasamos el objeto recibido y el ID del usuario que crea
            var idGenerado = await _usuarioRepository.InsertAsync(usuario, GetCurrentUserId());

            return CreatedAtAction(nameof(GetById), new { id = idGenerado }, usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.id_usuario)
                return BadRequest("El id de la URL no coincide con el del objeto");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _usuarioRepository.UpdateAsync(usuario, GetCurrentUserId());

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var existe = await _usuarioRepository.GetByIdAsync(id);
            if (existe == null) return NotFound();

            await _usuarioRepository.DeleteAsync(id, GetCurrentUserId());
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioRepository.LoginAsync(request.Username, request.Password);

            if (usuario == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            // Aquí normalmente generarías un Token JWT. 
            // Por ahora, solo devolveremos los datos del usuario.
            return Ok(new
            {
                Mensaje = "Login exitoso",
                Usuario = usuario.usuario,
                Rol = usuario.NombreRol
            });
        }

        // Clase de apoyo para recibir los datos
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}