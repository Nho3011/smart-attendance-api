using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SessionsRepositor(NpgsqlDataSource dataSource) : ISessionsRepository
    {
        public Task<int> AddAsync(Sessions entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Sessions>> GetAllAsync()
        {
            const string sql = "SELECT* FROM sessions ORDER BY session_id ;";
            await using var conn=await dataSource.OpenConnectionAsync();
            var result=await conn.QueryAsync<Sessions>(sql);
            return result.ToList();
        }

        public async Task<Sessions> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM sessions WHERE session_id=@Id";
            await using var conn=await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Sessions>(sql, new {Id=id});
        }

        public Task<int> UpdateAsync(Sessions entity)
        {
            throw new NotImplementedException();
        }
    }
}
