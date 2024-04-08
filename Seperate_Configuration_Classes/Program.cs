using Microsoft.EntityFrameworkCore;



class Order
{
    public int OrderId { get; set; }

    public string Description { get; set; }

    public DateTime OrderDate { get; set; }
}
class ApplicationDbContext:DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=ETest;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}

class OrderConfiguration:IEntityTypeConfiguration<Order>