using Redarbor.Domain.Employees;
using Microsoft.EntityFrameworkCore; 

namespace Redarbor.Application.Common.Interfaces
{
    public interface IApplicationDBContext
    {
        DbSet<Employee> Employees { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
