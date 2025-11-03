using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AttendanceRepository(NpgsqlDataSource dataSource) : IAttendanceRepository
    {
        public Task<int> AddAsync(Attendance entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Attendance>> GetAllAsync()
        {
            const string sql = "SELECT* FROM attendance ORDER BY attendance_id ;";
            await using var conn=await dataSource.OpenConnectionAsync();
            var result= await conn.QueryAsync<Attendance>(sql);
            return result.ToList();
        }

        public async Task<Attendance> GetByIdAsync(int id)
        {
            const string sql = "SELECT* FROM attendance WHERE attendance_id =@Id;";
            await using var conn = await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Attendance>(sql, new { Id=id });
        }

        public Task<int> UpdateAsync(Attendance entity)
        {
            throw new NotImplementedException();
        }
    }
}
