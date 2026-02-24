using MediatR;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Domain.Employees;

namespace Redarbor.Application.Employees.Queries;

public sealed class GetEmployeesHandler(IEmployeeReadRepository repo) : IRequestHandler<GetEmployeesQuery, IEnumerable<EmployeeDto>>
{
    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesQuery request, CancellationToken ct)
    {
        var employees = await repo.GetAllAsync(ct);

        return employees;
    }
}