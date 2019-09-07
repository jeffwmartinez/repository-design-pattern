using Microsoft.EntityFrameworkCore;
using RDP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDP.Service
{
    public class RepositoryService : IRepository
    {
        private ProductsDbContext _context;

        public RepositoryService(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            Products product = await GetProduct(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Products> GetProduct(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
