using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Delete(int id)
        {
            var objToDelete = await _context.Products.FindAsync(id);
            _context.Remove(objToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Product product)
        {
            if (!await _context.Products.AnyAsync(p => p.Id == id)) throw new KeyNotFoundException();
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}