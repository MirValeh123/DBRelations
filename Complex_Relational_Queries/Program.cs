using Microsoft.EntityFrameworkCore;
using System.Reflection;

ApplicationDbContext context = new ApplicationDbContext();


#region Query Syntax
//var query = from photo in context.Photos
//            join person in context.Persons
//            on photo.PersonId equals person.PersonId
//            select new
//            {
//                person.Name,
//                photo.Url
//            };
//var datas = await query.ToListAsync();


//var query = context.Photos
//    .Join(context.Persons, photo => photo.PersonId,
//    person => person.PersonId,
//    (photo, person) => new { photo.Url, person.Name });

//var datas = await query.ToListAsync();


//var query = from photo in context.Photos
//            join person in context.Persons
//            on new { photo.PersonId, photo.Url } equals new { person.PersonId, Url =  person.Name}
//            select new
//            {
//                person.Name,
//                photo.Url,
//            };
//var datas =  await query.ToListAsync();
//Console.WriteLine();
#endregion

#region Method Syntax

//var query = context.Photos
//    .Join(context.Persons,
//    photo => new
//    {
//        photo.PersonId,
//        photo.Url
//    },
//    persons => new
//    {
//        persons.PersonId,
//        Url = persons.Name
//    },
//    (photo, person) => new
//    {
//        person.Name,
//        photo.Url
//    });
//var datas = await query.ToListAsync();
//Console.WriteLine();

//var query = from photo in context.Photos
//            join person in context.Persons
//            on photo.PersonId equals person.PersonId
//            join order in context.Orders
//            on person.PersonId equals order.PersonId
//            select new
//            {
//                person.Name,
//                photo.Url,
//                order.Description
//            };
//var datas = await query.ToListAsync();

//Console.WriteLine();

//var query = context.Photos
//    .Join(context.Persons,
//    photo => photo.PersonId,
//    person => person.PersonId,
//    (photo, person) => new
//    {
//        person.PersonId,
//        person.Name,
//        photo.Url
//    })
//    .Join(context.Orders,
//    p => p.PersonId,
//    o => o.PersonId,
//    (person, order) => new 
//    { 
//        person.Name,
//        person.Url,
//        order.Description
//    });

//var datas = await query.ToListAsync();

//Console.WriteLine();

#endregion

#region Group Join - GroupBy degil!

//var query = from person in context.Persons
//            join order in context.Orders
//            on person.PersonId equals order.PersonId into personOrders

//            //from  order in personOrders
//            select new
//            {
//                person.Name,
//                Count = personOrders.Count(),
//                personOrders
//                //order.Description
//            };

//var datas = await query.ToListAsync();

//Console.WriteLine(datas);
#endregion

#region Left Join

//var query = from person in context.Persons
//            join order in context.Orders
//            on person.PersonId equals order.PersonId into personOrders

//            from order in personOrders.DefaultIfEmpty()
//            select new
//            {
//                person.Name,
//                order.Description
//            };

//var datas = await query.ToListAsync();

//Console.WriteLine();


#endregion

#region Right Join
//var query = from order in context.Orders
//            join person in context.Persons
//            on order.PersonId equals person.PersonId into orederPersons

//            from person in orederPersons.DefaultIfEmpty()
//            select new
//            {
//                person.Name,
//                order.Description
//            };

//var datas = await query.ToListAsync();

//Console.WriteLine();
#endregion

#region Full Join
//var leftQuery = from person in context.Persons
//                join order in context.Orders
//                on person.PersonId equals order.PersonId into personOrders
//                from order in personOrders.DefaultIfEmpty()
//                select new
//                {
//                    person.Name,
//                    order.Description
//                };


//var rightQuery = from order in context.Orders
//                join person in context.Persons
//                on order.PersonId equals person.PersonId into personOrders
//                from person in personOrders.DefaultIfEmpty()
//                select new
//                {
//                    person.Name,
//                    order.Description
//                };

//var fullJoin = leftQuery.Union(rightQuery);

//var datas = await fullJoin.ToListAsync();

//Console.WriteLine();


#endregion

#region Cross Join

//var query = from order in context.Orders
//            from person in context.Persons
//            select new
//            {
//                order,
//                person
//            };

//var data = await query.ToListAsync();
//Console.WriteLine(data);

#endregion

public class Photo
{
    public int PersonId { get; set; }
    public string Url { get; set; }

    public Person Person { get; set; }
}
public enum Gender { Man, Woman }
public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }

    public Photo Photo { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }

    public Person Person { get; set; }
}

class ApplicationDbContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Photo>()
            .HasKey(p => p.PersonId);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Photo)
            .WithOne(p => p.Person)
            .HasForeignKey<Photo>(p => p.PersonId);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER ;Database=ComplexRelationalDb;Trusted_Connection=True;TrustServerCertificate=true");
    }
}