using Redarbor.Application.Employees.Commands;

namespace Redarbor.Api.Contracts.Employees;

public static class CreateEmployeeMappings
{
    public static CreateEmployeeCommand ToCommand(this CreateEmployeeRequest request)
        => new(
            CompanyId: request.CompanyId,
            Email: request.Email,
            Fax: request.Fax,
            Name: request.Name,
            Password: request.Password,
            PortalId: request.PortalId,
            RoleId: request.RoleId,
            StatusId: request.StatusId,
            Telephone: request.Telephone,
            Username: request.Username
        );
}
