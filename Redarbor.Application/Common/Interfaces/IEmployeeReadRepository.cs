using Redarbor.Domain.Employees;

namespace Redarbor.Application.Common.Interfaces
{
    public interface IEmployeeReadRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken ct);
        Task<Employee?> GetByIdAsync(int id, CancellationToken ct);
    }
}
