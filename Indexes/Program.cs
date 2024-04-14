using Microsoft.EntityFrameworkCore;

AppDbContext context = new AppDbContext();

#region Composite Index


#endregion

//[Index(nameof(Name))]
//[Index(nameof(Name),nameof(Surname))]
//[Index(nameof(Name), IsUnique = true)]

//[Index(nameof(Name),AllDescending = true)]
[Index(nameof(Name), nameof(Surname),IsDescending = new[] {true,false})]

class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }


    public string? Surname { get; set; }

    public int Salary { get; set; }

}


class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=Index;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            //.HasIndex(e => e.Name);
            //.HasIndex(e => new { e.Name, e.Surname });
            .HasIndex(nameof(Employee.Name))
            .HasDatabaseName("name_index")
            .HasFilter("[Name] IS NOT NULL");
        //.IsUnique();

        //modelBuilder.Entity<Employee>()
        //    .HasIndex(x => new { x.Name, x.Surname })
        //    .IsDescending(true, false);

    }

}