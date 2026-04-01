using AcademicManager.Domain.Entities;
using AcademicManager.Domain.Interfaces;
using AcademicManager.Domain.Enums;
using AcademicManager.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;
namespace AcademicManager.Infrastructure.Repositories
{
    public class Alumno_padreRepository : IAlumno_padreRepository
    {
        private readonly DbContextSql _context;

        public Alumno_padreRepository(DbContextSql context)
        {
            _context = context;
        }



        public async Task<Alumno_padre?> GetByIdAsync(int id)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_padre_get_by_id", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@id_alumno_padre", SqlDbType.Int).Value = id;

            await ((SqlConnection)conn).OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync()) return null;

            // Obtenemos los ordinales una sola vez para mejorar el rendimiento
            int ordIdRelacion = reader.GetOrdinal("id_alumno_padre");
            int ordIdAlumno = reader.GetOrdinal("id_alumno");
            int ordIdPadre = reader.GetOrdinal("id_padre");
            int ordParentesco = reader.GetOrdinal("Parentesco"); // Asegura que este nombre coincida con el SELECT del SP

            return new Alumno_padre
            {
                id_alumno_padre = reader.GetInt32(ordIdRelacion),
                id_alumno = reader.GetInt32(ordIdAlumno),
                id_padre = reader.GetInt32(ordIdPadre),

                tipo_relacion = Enum.TryParse<TipoParentesco>(reader.GetString(ordParentesco), true, out var res)
                                ? res.ToString()
                                : TipoParentesco.Padre.ToString()
            };
        }


        public async Task<int> InsertAsync(Alumno_padre alumno_Padre, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_padre_insert", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure,
            };

            cmd.Parameters.AddWithValue("@id_alumno", alumno_Padre.id_alumno);
            cmd.Parameters.AddWithValue("@id_padre", alumno_Padre.id_padre);
            cmd.Parameters.AddWithValue("@tipo_relacion", alumno_Padre.tipo_relacion);

            cmd.Parameters.AddWithValue("@id_usuario_auditoria", idUsuarioAuditoria);

            await ((SqlConnection)conn).OpenAsync();

            var result = await cmd.ExecuteNonQueryAsync();

            return result; // ExecuteNonQuery devuelve el número de filas afectadas

        }
        public async Task UpdateAsync(Alumno_padre alumno_padre, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_padre_update",(SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure,
            };

            cmd.Parameters.AddWithValue("@id_alumno_padre", alumno_padre.id_alumno_padre);
            cmd.Parameters.AddWithValue("@id_alumno", alumno_padre.id_alumno);
            cmd.Parameters.AddWithValue("@id_padre", alumno_padre.id_padre);
            cmd.Parameters.AddWithValue("@tipo_relacion", alumno_padre.tipo_relacion);
            cmd.Parameters.AddWithValue("@id_usuario_auditoria", idUsuarioAuditoria);
             
            await ((SqlConnection)conn).OpenAsync();
            await cmd.ExecuteNonQueryAsync();
          
        }

        public async Task DeleteAsync(int id_alumno_padre, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_padre_delete", (SqlConnection)conn)
            {
                CommandType= CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@id_alumno_padre", id_alumno_padre);
            cmd.Parameters.AddWithValue("@id_Usuario_Auditoria", idUsuarioAuditoria);
            await((SqlConnection) conn).OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
