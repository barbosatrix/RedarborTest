using Redarbor.Domain.Employees;

namespace Redarbor.Application.Employees.Queries;
public sealed record EmployeeDto(
    int Id,
    int CompanyId,
    string Email,
    int PortalId,
    int RoleId,
    int StatusId,
    string Username,
    string? Name,
    string? Fax,
    string? Telephone,
    DateTime CreatedOn,
    DateTime? UpdatedOn,
    DateTime? DeletedOn,
    DateTime? Lastlogin
)
{
    public static EmployeeDto FromDomain(Employee e) => new(
            e.Id,
            e.CompanyId,
            e.Email,
            e.PortalId,
            e.RoleId,
            e.StatusId,
            e.Username,
            e.Name,
            e.Fax,
            e.Telephone,
            e.CreatedOn,
            e.UpdatedOn,
            e.DeletedOn,
            e.Lastlogin
        );
};