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


        /// <summary>
        /// Adds a product to the database
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>Task</returns>
        public async Task AddProduct(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Deletes the given item by id.  First it finds the product, then removes it, and saves the changes
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Task</returns>
        public async Task Delete(string id)
        {
            Products product = await GetProduct(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }


        /// <summary>
        /// Gets a single product by the id using LINQ
        /// </summary>
        /// <param name="id">string</param>
        /// <returns>Task</returns>
        public async Task<Products> GetProduct(string id)
        {
            return await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>Task</returns>
        public async Task<List<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }


        /// <summary>
        /// Updates the product that you want to edit, saves the changes in the database
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>Task</returns>
        public async Task UpdateProduct(Products product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
