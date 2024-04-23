using Microsoft.EntityFrameworkCore;
using System.Reflection;


AppDbContext context = new AppDbContext();

//var employee = await context.Employees.FirstOrDefaultAsync(e=>e.Id==2);

//if (employee.Name == "Gençay" )
//{
//    var orders = await context.Orders.Where(o => o.EmployeeId == employee.Id).ToListAsync();

//}

 #region Reference

//var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);
////...
////.....
//await context.Entry(employee).Reference(e=>e.Region).LoadAsync();

//Console.WriteLine();
#endregion

#region Collection

//var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);
////..........
////..........
////.......
//await context.Entry(employee).Collection(e => e.Orders).LoadAsync();

//Console.WriteLine();

#region Aggregate

//var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);
////..........
////..........
////.......
//var count = await context.Entry(employee).Collection(e => e.Orders).Query().CountAsync();

//Console.WriteLine();
#endregion

#region Filter

var employee = await context.Employees.FirstOrDefaultAsync(e => e.Id == 2);
//..........
//..........
//.......
await context.Entry(employee).Collection(e => e.Orders).Query().Where(o => o.OrderDate.Day == DateTime.Now.Day).ToListAsync() ;

Console.WriteLine();
#endregion

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