using Microsoft.EntityFrameworkCore;
using Redarbor.Application.Employees.Commands;
using Redarbor.Infrastructure.Persistence;

namespace Redarbor.UnitTests.Application.Employees;

public class CreateEmployeeHandlerTests
{
    [Fact]
    public async Task Handle_Should_CreateEmployee_And_ReturnId()
    {
        // Arrange: DbContext InMemory aislado por test
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: $"redarbor-tests-{Guid.NewGuid()}")
            .Options;

        await using var db = new ApplicationDbContext(options);

        var handler = new CreateEmployeeHandler(db);

        var command = new CreateEmployeeCommand(
            CompanyId: 1,
            Email: "test@email.com",
            Password: "P@ssw0rd!",
            PortalId: 2,
            RoleId: 3,
            StatusId: 1,
            Username: "john.doe",
            Name: "John",
            Fax: "123",
            Telephone: "555"
        );

        // Act
        var id = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(id > 0);

        var created = await db.Employees.FirstOrDefaultAsync(e => e.Id == id);
        Assert.NotNull(created);

        Assert.Equal(1, created!.CompanyId);
        Assert.Equal("test@email.com", created.Email);
        Assert.Equal("john.doe", created.Username);
        Assert.Equal("John", created.Name);
        Assert.Equal("123", created.Fax);
        Assert.Equal("555", created.Telephone);

        Assert.NotEqual(default, created.CreatedOn);
        Assert.NotNull(created.UpdatedOn);
        Assert.Null(created.DeletedOn);
    }
}