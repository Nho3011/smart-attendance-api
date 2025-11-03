using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CourseRepository(NpgsqlDataSource dataSource) : ICourseRepository
    {
        public Task<int> AddAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Course>> GetAllAsync()
        {
            const string sql = "SELECT*FROM course ORDER BY course_id;";
            await using var conn=dataSource.OpenConnection();
            var result=await conn.QueryAsync<Course>(sql);
            return result.ToList();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM course WHERE course_id=@Id;";
            await using var conn = await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Course>(sql, new { Id = id });

        }

        public Task<int> UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
