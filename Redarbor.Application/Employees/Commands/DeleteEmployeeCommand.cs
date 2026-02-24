using MediatR;

namespace Redarbor.Application.Employees.Commands;
public sealed record DeleteEmployeeCommand(int Id) : IRequest;

