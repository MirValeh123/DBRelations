using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

ESirketDbContext context = new();

#region One to One relatianol table remove data
//Calisan? calisan = await context.Calisanlar.Include(a=>a.CalisanAdresi)
//    .FirstOrDefaultAsync(c=>c.Id == 1);
//if (calisan != null )
//context.CalisanAdresleri.Remove(calisan.CalisanAdresi);

//await context.SaveChangesAsync(); 
#endregion



class Calisan
{
    public int Id { get; set; }

    public string Adi { get; set; }

    public CalisanAdresi CalisanAdresi { get; set; }
}

class CalisanAdresi
{
    [Key,ForeignKey(nameof(Calisan))]
    public int Id { get; set; }

    //public int CalisanId {  get; set; } 
    public string Adres { get; set; }

    public Calisan Calisan { get; set; }
}

class ESirketDbContext:DbContext
{
    public DbSet<Calisan> Calisanlar { get; set; }
    public DbSet<CalisanAdresi> CalisanAdresleri { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=ESirket;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CalisanAdresi>().HasKey(x => x.Id);

        modelBuilder.Entity<Calisan>()
            .HasOne(c=>c.CalisanAdresi)
            .WithOne(c=>c.Calisan)
            .HasForeignKey<CalisanAdresi>(ca => ca.Id);
    }
}
