using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;


AppDbContext context = new AppDbContext();

#region Lazy Loading 

var employee = await context.Employees.FindAsync(1);

Console.WriteLine();


#region ILazyLoading

#endregion
#endregion
public class Person
{
    public int Id { get; set; }

}
public class Employee : Person
{
    ILazyLoader _lazyLoader;
    Region _region;
    public Employee()
    {
        
    }
    public Employee(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }
    //public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }

    public virtual List<Order> Orders { get; set; }
    public virtual Region Region
    {
        get => _lazyLoader.Load(this, ref _region);
        set => _region = value;
    }
}
public class Region
{
    ILazyLoader _lazyLoader;
    ICollection<Employee> _employee;
    public Region()
    {
        
    }

    public Region(ILazyLoader lazyLoader)
    {
        _lazyLoader = lazyLoader;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Employee> Employees { get=>_lazyLoader.Load(this,ref _employee); set=>_employee = value; }
}
public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual Employee Employee { get; set; }
}



class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseLazyLoadingProxies()
        //     .UseSqlServer("Server=KOMPUTER ;Database=LazyLoading;Trusted_Connection=True;TrustServerCertificate=true");
        optionsBuilder.UseLazyLoadingProxies(false)
             .UseSqlServer("Server=KOMPUTER ;Database=LazyLoading;Trusted_Connection=True;TrustServerCertificate=true");
        //optionsBuilder.UseSqlServer("Server=KOMPUTER ;Database=LazyLoading;Trusted_Connection=True;TrustServerCertificate=true");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


    }




}