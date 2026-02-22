using MediatR;
using Redarbor.Application.Common.Interfaces;
using Redarbor.Domain.Employees;

namespace Redarbor.Application.Employees.Commands
{
    public sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private readonly IApplicationDbContext _db;

        public CreateEmployeeHandler(IApplicationDbContext db) => _db = db;

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

            _db.Employees.Add(employee);
            await _db.SaveChangesAsync(ct);

            return employee.Id;
        }
    }
}
