using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Application.Employees.Queries;
using Redarbor.Domain.Employees;
using System.Data;

namespace Redarbor.Infrastructure
{
    public sealed class EmployeeReadRepository(IConfiguration configuration) : IEmployeeReadRepository
    {
        private readonly string _cs = configuration.GetConnectionString("DefaultConnection")!;
        public IDbConnection CreateConnection() => new SqlConnection(_cs);
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken ct)
        {
            const string sql = """
                SELECT Id, CompanyId, Email, PortalId, RoleId, StatusId,
                       Username, Name, Fax, Telephone,
                       CreatedOn, UpdatedOn, DeletedOn, Lastlogin
                FROM Employees
            """;
            using var con = CreateConnection();
            return await con.QueryAsync<EmployeeDto>(sql);
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct)
        {
            const string sql = @"SELECT Id, CompanyId, Email, PortalId, RoleId, StatusId,
                   Username, Name, Fax, Telephone,
                   CreatedOn, UpdatedOn, DeletedOn, Lastlogin
            FROM Employees WHERE Id = @Id";
            using var con = CreateConnection();
            return await con.QueryFirstOrDefaultAsync<EmployeeDto>(sql, new { Id = id });
        }
    }
}