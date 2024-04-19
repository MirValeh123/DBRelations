using Microsoft.EntityFrameworkCore;
using System.Reflection;


AppDbContext context = new AppDbContext();

#region Lazy Loading 

var employee = await context.Employees.FindAsync(1);

#endregion
public class Person
{
    public int Id { get; set; }

}
public class Employee : Person
{
    //public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }

    public List<Order> Orders { get; set; }
    public Region Region { get; set; }
}
public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Employee> Employees { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public Employee Employee { get; set; }
}



class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER ;Database=ExplicitLoading;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.Entity<Employee>().Navigation(e => e.Region).AutoInclude();


    }




}