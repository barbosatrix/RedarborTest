using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Redarbor.Domain.Employees;

namespace Redarbor.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        // Required según prueba
        builder.Property(x => x.CompanyId).IsRequired();
        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(200);
        builder.Property(x => x.PortalId).IsRequired();
        builder.Property(x => x.RoleId).IsRequired();
        builder.Property(x => x.StatusId).IsRequired();
        builder.Property(x => x.Username).IsRequired().HasMaxLength(100);

        // Optional
        builder.Property(x => x.Name).HasMaxLength(200);
        builder.Property(x => x.Fax).HasMaxLength(50);
        builder.Property(x => x.Telephone).HasMaxLength(50);

        // Fechas
        builder.Property(x => x.CreatedOn).IsRequired();
        builder.Property(x => x.UpdatedOn);
        builder.Property(x => x.DeletedOn);
        builder.Property(x => x.Lastlogin);

        // Índices útiles
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();
    }
}
