using MediatR;
using Microsoft.EntityFrameworkCore;
using Redarbor.Application.Common.Interfaces;

namespace Redarbor.Application.Employees.Commands
{
    public sealed class UpdateEmployeeUsernameHandler(IApplicationDbContext db) : IRequestHandler<UpdateEmployeeUsernameCommand>
    {
        public async Task Handle(UpdateEmployeeUsernameCommand request, CancellationToken ct)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, ct) ?? throw new KeyNotFoundException($"Employee {request.Id} not found");

            employee.UpdateUsername(request.Username);
            await db.SaveChangesAsync(ct);
        }
    }
}