using Microsoft.EntityFrameworkCore;

namespace LapShop.DataBaseConnection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    }
}
