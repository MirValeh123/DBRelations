using Microsoft.EntityFrameworkCore;

AppDbContext appDbContext = new AppDbContext();
class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Url { get; set; }
    public ICollection<Post> Posts { get; set; }
}


class Post
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}

class AppDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>().HasAlternateKey(b => b.Url);
        modelBuilder.Entity<Blog>()
            .HasMany(b => b.Posts)
            .WithOne(b => b.Blog)
            .HasForeignKey(b => b.BlogId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=EConstraint;Trusted_Connection=True;TrustServerCertificate=true");
    }
}