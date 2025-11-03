using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class StudentRepository(NpgsqlDataSource dataSource) : IStudentRepository
    {
        public Task<int> AddAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync()
        {
            const string sql = "SELECT*FROM student ORDER BY student_id ";
            await using var conn= await dataSource.OpenConnectionAsync();
            var result=await conn.QueryAsync<Student>(sql);
            return result.ToList();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM student WHERE student_id=@Id;";
            await using var conn=await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Student>(sql,new {Id=id});   
        }

        public Task<int> UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
