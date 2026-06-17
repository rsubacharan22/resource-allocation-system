using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Client> Clients {get; set;}
    public DbSet<Project> Projects { get; set;}
    public DbSet<ResourceDemand> ResourceDemands { get; set; }
    public DbSet<AuditLog> AuditLogs {get; set;}
    public DbSet<Allocation> Allocations { get; set; }
}