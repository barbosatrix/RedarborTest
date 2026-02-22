using MediatR;
using Microsoft.EntityFrameworkCore;
using Redarbor.Application.Common.Interfaces;

namespace Redarbor.Application.Employees.Commands
{
    public sealed class UpdateEmployeeUsernameHandler : IRequestHandler<UpdateEmployeeUsernameCommand>
    {
        private readonly IApplicationDbContext _db;
        public UpdateEmployeeUsernameHandler(IApplicationDbContext db) => _db = db;

        public async Task Handle(UpdateEmployeeUsernameCommand request, CancellationToken ct)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
            if (employee is null) throw new KeyNotFoundException($"Employee {request.Id} not found");

            employee.UpdateUsername(request.Username);
            await _db.SaveChangesAsync(ct);
        }
    }
    }
}
