using AcademicManager.Domain.Entities;
using AcademicManager.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace AcademicManager.Infrastructure.Repositories
{
    public class UsuarioRepository : Domain.Interfaces.IUsuarioRepository
    {
        private readonly DbContextSql _context;


        public UsuarioRepository(DbContextSql context)
        {
            _context = context;
        }

        public Task DeleteAsync(int id_usuario, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("");


            throw new NotImplementedException();
        }

        public Task<Usuario?> GetByIdAsync(int id_usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> GetByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(Usuario usuario, int idUsuarioAuditoria)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Usuario usuario, int idUsuarioAuditoria)
        {
            throw new NotImplementedException();
        }
    }
}
