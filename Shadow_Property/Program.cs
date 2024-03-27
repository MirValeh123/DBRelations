

using Microsoft.EntityFrameworkCore;

ApplicationDbContext context = new ApplicationDbContext();


#region Foreign Key - Shadow Properties
//var blogs = await context.Blogs.Include(b => b.Posts).ToListAsync();
//Console.WriteLine();

#endregion


#region Shadow Property erisim
//var blog = await context.Blogs.FindAsync(3);
//var createdDate = context.Entry(blog).Property("CreatedDate");
//Console.WriteLine(createdDate.CurrentValue);
//Console.WriteLine(createdDate.OriginalValue);

//createdDate.CurrentValue = DateTime.Now;
//await context.SaveChangesAsync();
#endregion

#region EF.Property ile Erisim
var blogs = await context.Blogs.OrderBy(b => EF.Property<DateTime>(b, "CreatedDate")).ToListAsync();
Console.WriteLine();

#endregion
class Blog
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Post> Posts { get; set; }


}
   
class Post
{
    public int Id { get; set; }

    public string Title { get; set; }

    public bool lastUpdates { get; set; }

    public Blog Blog { get; set; }
}




class ApplicationDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=ShadowPropertiesDB;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Shadow Property olusturma
        modelBuilder.Entity<Blog>()
            .Property<DateTime>("CreatedDate");
        #endregion

    }
}
