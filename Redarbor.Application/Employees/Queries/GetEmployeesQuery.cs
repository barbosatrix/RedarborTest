using MediatR;

namespace Redarbor.Application.Employees.Queries;
public sealed record GetEmployeesQuery() : IRequest<IEnumerable<EmployeeDto>>;