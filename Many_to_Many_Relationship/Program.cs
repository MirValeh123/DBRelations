using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

Console.Read();

EJurnalDbContext dbContext = new EJurnalDbContext();

#region

var kitap = dbContext.Kitaplar.FirstOrDefault(k => k.Id == 1);

if (kitap != null)
{
    // Find the Yazar entry with Id = 1
    var yazar = dbContext.Yazarlar.FirstOrDefault(y => y.Id == 1);

    var kitapYazar = dbContext.KitapYazar.FirstOrDefault(ky => ky.KitapId == kitap.Id && ky.YazarId == yazar.Id);

    dbContext.KitapYazar.Remove(kitapYazar);

    // Save the changes to reflect the deletion in the database
    dbContext.SaveChanges();
    Console.WriteLine("Association between Kitap and Yazar removed successfully.");
}


#endregion

    #region Defalt Convention
    //class Kitap
    //{
    //    public int Id { get; set; }
    //    public string KitapAdi { get; set; }

    //    public List<Yazar> Yazarlar { get; set; }
    //}
    //class Yazar
    //{
    //    public int Id { get; set; }
    //    public string YazarAdi { get; set; }

    //    public List<Kitap> Kitaplar { get; set; }
    //}

    #endregion

    #region DATA ANNOTATIONS

    //class Kitap
    //{
    //    public int Id { get; set; }
    //    public string KitapAdi { get; set; }

    //    public List<Yazar> Yazarlar { get; set; }
    //}
    //class Yazar
    //{
    //    public int Id { get; set; }
    //    public string YazarAdi { get; set; }

    //    public List<Kitap> Kitaplar { get; set; }
    //}
    //class KitapYazar
    //{
    //    [ForeignKey(nameof(Kitap))]
    //    public int KId { get; set; }

    //    [ForeignKey(nameof(Yazar))]
    //    public int YId { get; set; }

    //    public Kitap Kitap { get; set; }
    //    public Yazar Yazar { get; set; }
    //}

    #endregion


    #region FLUENT API

class Kitap
{
    public int Id { get; set; }
    public string KitapAdi { get; set; }

    public ICollection<KitapYazar> Yazarlar { get; set; }
}
//Cross Table
class KitapYazar
{
    public int KitapId { get; set; }
    public int YazarId { get; set; }

    public Kitap Kitap { get; set; }
    public Yazar Yazar { get; set; }
}
class Yazar
{
    public int Id { get; set; }
    public string YazarAdi { get; set; }

    public ICollection<KitapYazar> Kitaplar { get; set; }
}
#endregion
class EJurnalDbContext : DbContext
{
    public DbSet<Kitap> Kitaplar { get; set; }
    public DbSet<Yazar> Yazarlar { get; set; }
    public DbSet<KitapYazar> KitapYazar { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=EKitap;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KitapYazar>()
            .HasKey(ky => new { ky.KitapId, ky.YazarId });

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Kitap)
            .WithMany(ky => ky.Yazarlar)
            .HasForeignKey(ky => ky.KitapId);

        modelBuilder.Entity<KitapYazar>()
            .HasOne(ky => ky.Yazar)
            .WithMany(ky => ky.Kitaplar)
            .HasForeignKey(ky => ky.YazarId);
    }
}
