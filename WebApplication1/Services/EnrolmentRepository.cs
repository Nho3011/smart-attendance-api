using Dapper;
using Npgsql;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EnrolmentRepository(NpgsqlDataSource dataSource) : IEnrolmentRepository
    {
        public Task<int> AddAsync(Enrolment entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Enrolment>> GetAllAsync()
        {
            const string sql = "SELECT*FROM enrolment ORDER BY enrolment_id";
            await using var conn= await dataSource.OpenConnectionAsync();
            var result= await conn.QueryAsync<Enrolment>(sql);
            return result.ToList();
        }

        public async Task<Enrolment> GetByIdAsync(int id)
        {
            const string sql = "SELECT*FROM enrolment WHERE enrolment_id=@Id;";
            await using var conn=await dataSource.OpenConnectionAsync();
            return await conn.QuerySingleOrDefaultAsync<Enrolment>(sql, new { Id = id });
        }

        public Task<int> UpdateAsync(Enrolment entity)
        {
            throw new NotImplementedException();
        }
    }
}
