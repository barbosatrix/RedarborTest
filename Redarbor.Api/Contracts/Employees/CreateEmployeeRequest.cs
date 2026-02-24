namespace Redarbor.Api.Contracts.Employees
{
    public sealed record CreateEmployeeRequest(
        int CompanyId,
        DateTime CreatedOn,
        DateTime? DeletedOn,
        string Email,
        string? Fax,
        string? Name,
        DateTime? Lastlogin,
        string Password,
        int PortalId,
        int RoleId,
        int StatusId,
        string? Telephone,
        DateTime? UpdatedOn,
        string Username
    );
}
