using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

ApplicationDbContext context = new ApplicationDbContext();

Person person = new Person()
{
    Id = 1,
    Name = "MirTaleh",
    SurName = "İbrahimli",
    Premium = 20,

};
context.Persons.Add(person);
context.SaveChanges();


class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // --ValueGeneratedNever
    public int Id { get; set; }
    public string Name { get; set; }

    public string SurName { get; set; }

    public int Premium { get; set; }
    public int Salary { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public int TotalGain { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // --ValueGeneratedOnAdd

    public int PersonCode { get; set; }



}
class ApplicationDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=ETest;Trusted_Connection=True;TrustServerCertificate=true");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(p => p.Salary)
            //.HasDefaultValue(100);
            .HasDefaultValueSql("FlOOR(RAND() * 1000)");
        modelBuilder.Entity<Person>().Property(t => t.TotalGain).HasComputedColumnSql("([Salary] + [Premium]) * 10")
            .ValueGeneratedOnAddOrUpdate();

        //modelBuilder.Entity<Person>().Property(t=>t.Id).ValueGeneratedNever();

        //modelBuilder.Entity<Person>().Property(t => t.Id).ValueGeneratedOnAdd();
    }
}