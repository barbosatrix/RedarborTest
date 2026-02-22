using Ardalis.GuardClauses;

namespace Redarbor.Domain.Employees
{
    public class Employee
    {
        public int Id { get; private set; }

        // Required (según prueba)
        public int CompanyId { get; private set; }
        public string Email { get; private set; } = default!;
        public string Password { get; private set; } = default!;
        public int PortalId { get; private set; }
        public int RoleId { get; private set; }
        public int StatusId { get; private set; }
        public string Username { get; private set; } = default!;

        // Optional
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public DateTime? Lastlogin { get; private set; }
        public string? Name { get; private set; }
        public string? Fax { get; private set; }
        public string? Telephone { get; private set; }

        private Employee() { } // EF

        private Employee(
            int companyId,
            string email,
            string password,
            int portalId,
            int roleId,
            int statusId,
            string username)
        {
            CompanyId = Guard.Against.Zero(companyId, nameof(companyId));
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email)).Trim();
            Password = Guard.Against.NullOrWhiteSpace(password, nameof(password));
            PortalId = Guard.Against.Zero(portalId, nameof(portalId));
            RoleId = Guard.Against.Zero(roleId, nameof(roleId));
            StatusId = Guard.Against.Zero(statusId, nameof(statusId));
            Username = Guard.Against.NullOrWhiteSpace(username, nameof(username)).Trim();

            var now = DateTime.UtcNow;
            CreatedOn = now;
            UpdatedOn = now;

            DeletedOn = null;
            Lastlogin = null;
        }

        // ✅ Factory: el dominio decide fechas/estado inicial
        public static Employee Create(
            int companyId,
            string email,
            string password,
            int portalId,
            int roleId,
            int statusId,
            string username,
            string? name = null,
            string? fax = null,
            string? telephone = null)
        {
            var employee = new Employee(companyId, email, password, portalId, roleId, statusId, username);
            employee.SetOptionalData(name, fax, telephone);
            return employee;
        }

        // ✅ Updates controlados
        public void UpdateUsername(string username)
        {
            Username = Guard.Against.NullOrWhiteSpace(username, nameof(username)).Trim();
            Touch();
        }

        public void UpdateEmail(string email)
        {
            Email = Guard.Against.NullOrWhiteSpace(email, nameof(email)).Trim();
            Touch();
        }

        public void UpdatePassword(string password)
        {
            Password = Guard.Against.NullOrWhiteSpace(password, nameof(password));
            Touch();
        }

        public void UpdateRequiredIds(int portalId, int roleId, int statusId)
        {
            PortalId = Guard.Against.Zero(portalId, nameof(portalId));
            RoleId = Guard.Against.Zero(roleId, nameof(roleId));
            StatusId = Guard.Against.Zero(statusId, nameof(statusId));
            Touch();
        }

        // ✅ Opcionales
        public void SetOptionalData(string? name, string? fax, string? telephone)
        {
            Name = NormalizeNullable(name);
            Fax = NormalizeNullable(fax);
            Telephone = NormalizeNullable(telephone);
            Touch();
        }

        // ✅ Soft delete
        public void MarkAsDeleted()
        {
            if (DeletedOn is not null) return;
            DeletedOn = DateTime.UtcNow;
            Touch();
        }

        public void RegisterLogin(DateTime? when = null)
        {
            Lastlogin = when ?? DateTime.UtcNow;
            Touch();
        }

        private void Touch() => UpdatedOn = DateTime.UtcNow;

        private static string? NormalizeNullable(string? value)
        {
            var v = value?.Trim();
            return string.IsNullOrEmpty(v) ? null : v;
        }
    }
}
