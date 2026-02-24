using MediatR;

namespace Redarbor.Application.Employees.Commands
{
    public sealed record CreateEmployeeCommand(
        int CompanyId,
        string Email,
        string? Fax,
        string? Name,
        string Password,
        int PortalId,
        int RoleId,
        int StatusId,
        string? Telephone,
        string Username
    ) : IRequest<int>;
}
