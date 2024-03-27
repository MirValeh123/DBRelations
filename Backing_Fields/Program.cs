using Microsoft.EntityFrameworkCore;


BackingFieldsDbContext context = new BackingFieldsDbContext();

var person = await context.Persons.FindAsync(3);

//Person person1 = new()
//{
//    Name = "MirValeh",
//    Department = "Dp1"
//};
//Person person2 = new()
//{
//    Name = "MirTaleh",
//    Department = "Dp2"
//};
//Person person3 = new()
//{
//    Name = "MirSaleh",
//    Department = "Dp3"
//};

//await context.Persons.AddRangeAsync(person1,person2,person3);
//await context.SaveChangesAsync();

Console.Read();

#region BackingFields Attribute
//class Person
//{
//    public int Id { get; set; }

//    public string name;

//    [BackingField(nameof(name))]
//    public string Name { get => name.Substring(0, 3); set => name = value; }
//    //public string Name { get; set; }

//    public string Department { get; set; }
//}

#endregion

#region HasField Fluent APi
//class Person
//{
//    public int Id { get; set; }

//    public string name;


//    public string Name { get; set; }

//    public string Department { get; set; }
//}

#endregion

#region Field-Only Properties
class Person
{
    public int Id { get; set; }

    public string name;

    public string Department { get; set; }
}

#endregion

class BackingFieldsDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=BackingFieldsDB;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>()
        //    .Property(x => x.Name)
        //    .HasField(nameof(Person.name))
        #region Field And Property Access
        //.UsePropertyAccessMode(PropertyAccessMode.Property);
        //.UsePropertyAccessMode(PropertyAccessMode.Field);
        #endregion

        #region Field-Only Properties
        modelBuilder.Entity<Person>()
            .Property(nameof(Person.name));

        #endregion

    }
}