using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.Repositories;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepository.GetProduct(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return new OkObjectResult(products);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            return await _productRepository.Create(product);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete = await _productRepository.GetProduct(id);
            if (productToDelete == null) return new NotFoundResult();
            await _productRepository.Delete(id);
            return new OkResult();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] Product product)
        {
            if (product.Id != id) return new BadRequestResult();
            await _productRepository.Update(id, product);
            return new NoContentResult();
        }
    }
}
