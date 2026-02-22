using MediatR;

namespace Redarbor.Application.Employees.Commands
{
    public sealed record UpdateEmployeeUsernameCommand(int Id, string Username) : IRequest;
}
