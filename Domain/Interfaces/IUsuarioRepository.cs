
using AcademicManager.Domain.Entities;

namespace AcademicManager.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> InsertAsync(Usuario usuario, int idUsuarioAuditoria);
        Task UpdateAsync(Usuario usuario, int idUsuarioAuditoria);
        Task DeleteAsync(int id_usuario, int idUsuarioAuditoria);
        Task<Usuario?> GetByIdAsync(int id_usuario);
        Task<Usuario?> GetByUsernameAsync(string username);
    }
}
