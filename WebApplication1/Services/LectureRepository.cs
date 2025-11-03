using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LectureRepository(NpgsqlDataSource dataSource) : ILecturerRepository
    {
        public Task<int> AddAsync(Lecturer entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Lecturer>> GetAllAsync()
        {
            const string sql = "SELECT*FROM lecture ORDER BY user_id;";
            await using var conn=await dataSource.OpenConnectionAsync();
            var result= await conn.QueryAsync<Lecturer>(sql);
            return result.ToList();
        }

        public async Task<Lecturer> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM lecturer  WHERE user_id=@Id;";
            await using var conn= await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Lecturer>(sql, new { Id=id });
        }

        public Task<int> UpdateAsync(Lecturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
