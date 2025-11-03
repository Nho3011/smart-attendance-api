using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UsersRepository(NpgsqlDataSource dataSource) : IUsersRepository
    {
        public async Task<Users> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM users WHERE id=@Id;";
            await using var conn = await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Users>(sql, new { Id = id });
        }
        public async Task<IReadOnlyList<Users>> GetAllAsync()
        {
            const string sql = "SELECT * FROM users ORDER BY id;";
            await using var conn=await dataSource.OpenConnectionAsync();
            var result=await conn.QueryAsync<Users>(sql);
            return result.ToList();
        }
        public Task<int> AddAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
