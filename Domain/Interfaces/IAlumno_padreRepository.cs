using AcademicManager.Domain.Entities;

namespace AcademicManager.Domain.Interfaces
{
    public interface IAlumno_padreRepository
    {
        Task <int> InsertAsync (Alumno_padre alumno_Padre, int idUsuarioAuditoria);
        Task UpdateAsync(Alumno_padre alumno_padre, int idUsuarioAuditoria);
        Task DeleteAsync(int id_alumno_padre, int idUsuarioAuditoria);
        Task<Alumno_padre> GetByIdAsync (int id);
    }
}
