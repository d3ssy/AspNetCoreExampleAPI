using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models;

namespace ProductsApi.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(int id);
        Task<IEnumerable<Product>> GetProducts();
         Task<Product> Create(Product product);
         Task Delete(int id);
        Task Update(int id, Product product);
    }
}