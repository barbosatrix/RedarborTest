using MediatR;
using Redarbor.Application.Common.Interfaces;

namespace Redarbor.Application.Employees.Queries;

public sealed class GetEmployeeByIdHandler(IEmployeeReadRepository repository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
{
    public async Task<EmployeeDto?> Handle(
        GetEmployeeByIdQuery request,
        CancellationToken ct)
    {
        var employee = await repository.GetByIdAsync(request.Id, ct);

        return employee is null
            ? null
            : employee;
    }
}