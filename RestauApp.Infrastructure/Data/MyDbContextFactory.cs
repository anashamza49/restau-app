using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestauApp.Infrastructure.Data
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-FB9I7I1;Database=restaudb;Trusted_Connection=True;TrustServerCertificate=True;",
                b => b.MigrationsAssembly("RestauApp.Infrastructure"));

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}
