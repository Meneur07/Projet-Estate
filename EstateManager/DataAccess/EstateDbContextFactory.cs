using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EstateManager.DataAccess
{
    public class EstateDbContextFactory : IDesignTimeDbContextFactory<EstateManagerContext>
    {
        public EstateManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EstateManagerContext>();
            optionsBuilder.UseSqlite("Data Source=estate.db");

            return new EstateManagerContext(optionsBuilder.Options);
        }
    }

}
