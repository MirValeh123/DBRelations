using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();

await context.Employees.AddAsync(new() { Name = "Mirvaleh", Surname = "İbrahimli", Salary = 2000 });
await context.Employees.AddAsync(new() { Name = "Mirtaleh", Surname = "İbrahimli", Salary = 2000 });
await context.Employees.AddAsync(new() { Name = "Mirsaleh", Surname = "İbrahimli", Salary = 2000 });

await context.Customers.AddAsync(new() { Name = "Gulnare" });


await context.SaveChangesAsync();

class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }


    public string? Surname { get; set; }

    public int Salary { get; set; }

}

class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }
}


class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Customer> Customers { get; set; } 

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=Sequences;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasSequence("EC_Sequence");

        modelBuilder.Entity<Employee>().Property(e => e.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");

        modelBuilder.Entity<Customer>().Property(c => c.Id)
            .HasDefaultValueSql("NEXT VALUE FOR EC_Sequence");

    }

}