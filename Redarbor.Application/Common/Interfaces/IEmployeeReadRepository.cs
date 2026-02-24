using Redarbor.Application.Employees.Queries;

namespace Redarbor.Application.Common.Interfaces
{
    public interface IEmployeeReadRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync(CancellationToken ct);
        Task<EmployeeDto?> GetByIdAsync(int id, CancellationToken ct);
    }
}
