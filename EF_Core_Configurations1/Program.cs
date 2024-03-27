using Microsoft.EntityFrameworkCore;

ApplicatonDbContext context = new ApplicatonDbContext();


#region Configuration | Data Annotations , Fluent API

#region Table-ToTable
#endregion

#endregion

class ApplicatonDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=MIRVALEH;Database=EDepartman;Trusted_Connection=True;TrustServerCertificate=true");
    }
}