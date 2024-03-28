using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

ApplicatonDbContext context = new ApplicatonDbContext();


#region Configuration | Data Annotations , Fluent API

//[Table("Kisiler")]
class Person
{
    public int Id { get; set; }

    //[ForeignKey(nameof(School))]
    public int TestSchoolId { get; set; }
    //[Column("Adi", TypeName = "Metin",Order =3)]
    public string Name { get; set; } = string.Empty;
    public string FirstName { get; set; }
    = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }

}

class School
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Person> Persons { get; set; }

}
#endregion



class ApplicatonDbContext : DbContext
{
    public DbSet<Person> Peoples { get; set; }
    public DbSet<School> Schools { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=EDepartman;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>().ToTable("Kisiler");
        //modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnName("Adi").HasColumnType("Metin").HasColumnOrder(3);
        modelBuilder.Entity<School>().HasOne(p => p.Persons).WithMany(x=>x.)
    }
}