using MediatR;
using Microsoft.EntityFrameworkCore;
using Redarbor.Application.Common.Interfaces;

namespace Redarbor.Application.Employees.Commands;
public sealed class DeleteEmployeeHandler(IApplicationDbContext db) : IRequestHandler<DeleteEmployeeCommand>
{
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken ct)
    {
        var employee = await db.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, ct);
        if (employee is null) return;

        db.Employees.Remove(employee);
        await db.SaveChangesAsync(ct);
    }
}
