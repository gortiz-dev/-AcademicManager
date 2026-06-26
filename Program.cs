using AcademicManager.Domain.Interfaces;
using AcademicManager.Infrastructure.Repositories;
using AcademicManager.Infrastructure.Data; // <--- AGREGAR ESTO

namespace AcademicManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ========================
            // Inyecci�n de dependencias
            // ========================

            // Cambiado a Scoped para mejor manejo de conexiones SQL
            builder.Services.AddScoped<DbContextSql>();

           builder.Services.AddScoped<IAlumnoRepository, AlumnoRepository>();
           builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
           builder.Services.AddScoped<IAlumno_padreRepository, Alumno_padreRepository>();
            // ========================
            // Servicios base
            // ========================
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ========================
            // Middleware
            // ========================
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}