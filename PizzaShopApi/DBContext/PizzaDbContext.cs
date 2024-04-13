using Microsoft.EntityFrameworkCore;
using PizzaShopApi.Models;

namespace PizzaShopApi.DBContext
{
    public class PizzaDbContext:DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) 
        {

        }

        public DbSet<Pizza> Pizza { get; set; } = null;
    }
}
