using AcademicManager.Domain.Entities;

namespace AcademicManager.Domain.Interfaces
{
    public interface IAlumnoRepository
    {
        // Agregamos el idUsuarioAuditoria a los métodos de escritura (CUD)
        Task<int> InsertAsync(Alumno alumno, int idUsuarioAuditoria);
        Task UpdateAsync(Alumno alumno, int idUsuarioAuditoria);
        Task DeleteAsync(int id_alumno, int idUsuarioAuditoria);

        // El GET se queda igual porque no genera auditoría de cambio
        Task<Alumno?> GetByIdAsync(int id);
    }
}