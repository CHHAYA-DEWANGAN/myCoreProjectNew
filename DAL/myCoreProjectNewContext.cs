using Microsoft.EntityFrameworkCore;
using myCoreProjectNew.Models;

namespace myCoreProjectNew.DAL
{
    public class myCoreProjectNewContext : DbContext
    {
        public myCoreProjectNewContext(DbContextOptions<myCoreProjectNewContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
