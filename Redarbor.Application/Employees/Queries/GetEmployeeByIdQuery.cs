using MediatR;

namespace Redarbor.Application.Employees.Queries;

public sealed record GetEmployeeByIdQuery(int Id)
    : IRequest<EmployeeDto?>;