using AcademicManager.Domain.Entities;
using AcademicManager.Domain.Interfaces;
using AcademicManager.Domain.Enums; 
using AcademicManager.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AcademicManager.Infrastructure.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private readonly DbContextSql _context;

        public AlumnoRepository(DbContextSql context)
        {
            _context = context;
        }

        public async Task<Alumno?> GetByIdAsync(int id)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_get_by_id", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id_alumno", id);

            await ((SqlConnection)conn).OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            if (!reader.Read())
                return null;

            return new Alumno
            {
                id_alumno = reader.GetInt32(reader.GetOrdinal("id_alumno")),
                nombre = reader.GetString(reader.GetOrdinal("nombre")),
                apellido = reader.GetString(reader.GetOrdinal("apellido")),
                email = reader.GetString(reader.GetOrdinal("email")),
                domicilio = reader.IsDBNull(reader.GetOrdinal("domicilio"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("domicilio")),
                celular = Convert.ToInt32(reader["celular"]),
                estado = Enum.TryParse<EstadoGeneral>(reader["estado"].ToString(), true, out var estadoEnum)
         ? estadoEnum
         : EstadoGeneral.Activo // Valor por defecto si falla la conversión
            };
        }

        public async Task<int> InsertAsync(Alumno alumno, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_insert", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
            cmd.Parameters.AddWithValue("@apellido", alumno.apellido);
            cmd.Parameters.AddWithValue("@email", alumno.email);
            cmd.Parameters.AddWithValue("@domicilio", (object?)alumno.domicilio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@celular", alumno.celular);
            cmd.Parameters.AddWithValue("@estado", (int)alumno.estado);
            cmd.Parameters.AddWithValue("@id_usuario_auditoria", idUsuarioAuditoria);

            await ((SqlConnection)conn).OpenAsync();

            // Para que devuelva el ID real generado, usa ExecuteScalar y pon un SELECT en tu SP
            var result = await cmd.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }

        public async Task UpdateAsync(Alumno alumno, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_update", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id_alumno", alumno.id_alumno);
            cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
            cmd.Parameters.AddWithValue("@apellido", alumno.apellido);
            cmd.Parameters.AddWithValue("@email", alumno.email);
            cmd.Parameters.AddWithValue("@domicilio", (object?)alumno.domicilio ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@celular", alumno.celular);
            cmd.Parameters.AddWithValue("@estado", (int)alumno.estado);
            cmd.Parameters.AddWithValue("@id_usuario_auditoria", idUsuarioAuditoria);

            await ((SqlConnection)conn).OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id_alumno, int idUsuarioAuditoria)
        {
            using var conn = _context.CreateConnection();
            using var cmd = new SqlCommand("sp_alumno_delete", (SqlConnection)conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id_alumno", id_alumno);
            cmd.Parameters.AddWithValue("@id_usuario_auditoria", idUsuarioAuditoria);

            await ((SqlConnection)conn).OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
    }
}