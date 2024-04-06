using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

ApplicatonDbContext context = new ApplicatonDbContext();

//Person p = new Person();
//p.School = new()
//{
//    Name = "229"
//};
//p.Age = 14;
//p.Name = "Eli";
//p.FirstName = string.Empty;
//p.LastName = string.Empty;
//await context.Peoples.AddAsync(p);
//await context.SaveChangesAsync();  
var person = context.Peoples.First();
person.Name = "Valeh";
context.SaveChanges();
Console.WriteLine();


#region Configuration | Data Annotations , Fluent API

//[Table("Kisiler")]
class Person
{
    public int Id { get; set; }

    //public int Id2 { get; set; }
    //[Key]
    //public int PID { get; set; }

    //[ForeignKey(nameof(School))]
    public int TestSchoolId { get; set; }

    //[Column("Adi", TypeName = "Metin",Order =3)]
    public string Name { get; set; } = string.Empty;
    public string FirstName { get; set; }
    = string.Empty;

    //[NotMapped]
    public string LastName { get; set; } = string.Empty;

    //[Required]
    public int Age { get; set; }

    //[Timestamp]
    public byte[] RowVersion { get; set; }
    public School School { get; set; }

}

class School
{
    public int Id { get; set; }

    //[MaxLength(20)]
    public string Name { get; set; } = string.Empty;
    public ICollection<Person> Persons { get; set; }

}


class Test
{
    //public int Id { get; set; }
    public int Num1 { get; set; }
    public int Num2 { get; set; }

    public int Result { get; set; }
}
#endregion



class ApplicatonDbContext : DbContext
{
    public DbSet<Person> Peoples { get; set; }
    public DbSet<School> Schools { get; set; }

    public DbSet<Test> Tests { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=EOkul;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>().ToTable("Kisiler");
        //modelBuilder.Entity<Person>().Property(p => p.Name).HasColumnName("Adi").HasColumnType("Metin").HasColumnOrder(3);
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.School)
        //    .WithMany(x => x.Persons)
        //    .HasForeignKey(x => x.TestSchoolId);

        //modelBuilder.Entity<Person>().Ignore(x => x.LastName);

        //modelBuilder.Entity<Person>().HasKey(p=>p.PID);

        //modelBuilder.Entity<Person>().Property(p => p.RowVersion).IsRowVersion();
        //modelBuilder.Entity<Person>().Property(p=>p.Age).IsRequired();

        //modelBuilder.Entity<School>().Property(s => s.Name).HasMaxLength(20);

        //modelBuilder.Entity<Person>().HasKey(p => new {p.Id,p.Id2 });

        modelBuilder.Entity<Test>().HasNoKey();
        modelBuilder.Entity<Test>().Property(t => t.Result).HasComputedColumnSql("[Num1] + [Num2]");
         
    }
}