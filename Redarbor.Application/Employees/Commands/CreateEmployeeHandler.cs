using MediatR;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Domain.Employees;

namespace Redarbor.Application.Employees.Commands
{
    public sealed class CreateEmployeeHandler(IApplicationDbContext db) : IRequestHandler<CreateEmployeeCommand, int>
    {
        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken ct)
        {
            var employee = Employee.Create(
                request.CompanyId,
                request.Email,
                request.Password,
                request.PortalId,
                request.RoleId,
                request.StatusId,
                request.Username,
                name: request.Name,
                fax: request.Fax,
                telephone: request.Telephone
            );

            db.Employees.Add(employee);
            await db.SaveChangesAsync(ct);

            return employee.Id;
        }
    }
}
