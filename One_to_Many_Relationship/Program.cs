using Microsoft.EntityFrameworkCore;

ESirketDbContext context = new();

Departman? calisan = await context.Departmen.FindAsync(3);
if (calisan != null)
{
    context.Departmen.Remove(calisan);
    await context.SaveChangesAsync();
}
#region One To Many relational table remove data

//Departman? departman = await context.Departmen.Include(c=>c.Calisanlar)
//    .FirstOrDefaultAsync(d=>d.Id == 1);

//Calisan? calisan = departman.Calisanlar.FirstOrDefault(d=>d.Id == 1);

//context.Calisanlar.Remove(calisan); 

//await context.SaveChangesAsync();
#endregion

//Defalt Convention
//class Calisan
//{
//    public int Id { get; set; }

//    public string Adi { get; set; }

//    public Departman Departman { get; set; }
//}

//class Departman
//{
//    public int Id { get; set; }

//    public string DepartmanAdi { get; set; }

//    public ICollection<Calisan> Calisanlar { get; set; }
//}


//DATA ANNOTATIONS
//class Calisan
//{
//    public int Id { get; set; }

//    [ForeignKey(nameof(Departman))]
//    public int DId { get; set; }
//    public string Adi { get; set; }

//    public Departman Departman { get; set; }
//}

//class Departman
//{
//    public int Id { get; set; }

//    public string DepartmanAdi { get; set; }

//    public ICollection<Calisan> Calisanlar { get; set; }
//}


//FLUENT API
class Calisan
{
    public int Id { get; set; }

    public string Adi { get; set; }

    public int? DId { get; set; }
    public Departman Departman { get; set; }
}

class Departman
{
    public int Id { get; set; }

    public string DepartmanAdi { get; set; }

    public ICollection<Calisan> Calisanlar { get; set; }
}


class ESirketDbContext : DbContext
{
    public DbSet<Departman> Departmen {  get; set; }
    public DbSet<Calisan> Calisanlar { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=EDepartman;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calisan>()
            .HasOne(c => c.Departman)
            .WithMany(d => d.Calisanlar)
            .HasForeignKey(c => c.DId)
            //.OnDelete(DeleteBehavior.SetNull);
            .OnDelete(DeleteBehavior.Restrict);
    }
}
