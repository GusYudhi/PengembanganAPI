using PengembanganAPI.Data;
using PengembanganAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PengembanganAPI.Repository
{
    public interface IProdukRepository
    {
        Task<ICollection<Produk>> GetProduksAsync();
        Task<Produk?> GetProdukAsync(int id);
        Task AddProdukAsync(Produk produk);
        Task UpdateProdukAsync(Produk produk);
        Task DeleteProdukAsync(Produk produk);
    }

    public class ProdukRepository : IProdukRepository
    {
        private readonly DataContext _context;

        public ProdukRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Produk>> GetProduksAsync()
        {
            return await _context.Produks.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<Produk?> GetProdukAsync(int id)
        {
            return await _context.Produks.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddProdukAsync(Produk produk)
        {
            await _context.Produks.AddAsync(produk);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProdukAsync(Produk produk)
        {
            _context.Produks.Update(produk);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProdukAsync(Produk produk)
        {
            _context.Produks.Remove(produk);
            await _context.SaveChangesAsync();
        }

    }
}
