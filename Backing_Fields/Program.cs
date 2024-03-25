﻿using Microsoft.EntityFrameworkCore;


BackingFieldsDbContext context = new BackingFieldsDbContext();

var person = await context.Persons.FindAsync(3);

//Person person2 = new()
//{
//    Name = "Fateh",
//    Department = "Dp3"

//};

//context.Persons.Add(person2);
//context.SaveChanges();

Console.Read();

#region BackingFields Attribute
//class Person
//{
//    public int Id { get; set; }

//    public string name;

//    [BackingField(nameof(name))]
//    //public string Name { get => name.Substring(0, 3); set => name = value; }
//    public string Name { get; set; }

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
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=BackingFieldsDB;Trusted_Connection=True;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Person>()
        //    .Property(x => x.Name)
        //    .HasField(nameof(Person.name))
        #region Field And Property Access
        //.UsePropertyAccessMode(PropertyAccessMode.Property);
        #endregion

        #region Field-Only Properties
        modelBuilder.Entity<Person>()
            .Property(nameof(Person.name));

        #endregion

    }
}