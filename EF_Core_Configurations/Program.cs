using Microsoft.EntityFrameworkCore;

class AppLicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=KOMPUTER;Database=EDepartman;Trusted_Connection=True;TrustServerCertificate=true");
    }
}