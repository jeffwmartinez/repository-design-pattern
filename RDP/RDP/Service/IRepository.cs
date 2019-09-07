using RDP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDP.Service
{
    public interface IRepository
    {
        Task AddProduct(Products product);
        Task<Products> GetProduct(string id);
        Task<List<Products>> GetProducts();
        Task UpdateProduct(Products product);
        Task Delete(string id);
    }
}
