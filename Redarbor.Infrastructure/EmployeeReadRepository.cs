using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Domain.Employees;
using System.Data;

namespace Redarbor.Infrastructure
{
    public sealed class EmployeeReadRepository(IConfiguration configuration) : IEmployeeReadRepository
    {
        private readonly string _cs = configuration.GetConnectionString("DefaultConnection")!;
        public IDbConnection CreateConnection() => new SqlConnection(_cs);
        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken ct)
        {
            const string sql = @"SELECT * FROM EMPLOYEES";
            using var con = CreateConnection();
            return await con.QueryAsync<Employee>(sql);
        }

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken ct)
        {
            const string sql = @"SELECT * FROM Employees WHERE Id = @Id";
            using var con = CreateConnection();
            return await con.QueryFirstOrDefaultAsync<Employee>(sql, new { Id = id });
        }
    }
}