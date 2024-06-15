using Microsoft.EntityFrameworkCore;
using PengembanganAPI.Models;

namespace PengembanganAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produk> Produks { get; set; }
    }
}
