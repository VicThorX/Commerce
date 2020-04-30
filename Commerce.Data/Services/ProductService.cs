using Commerce.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ICommerceContext _commerceContext;

        public ProductService(ICommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _commerceContext.Products.Find(product => true).ToListAsync();
        }

        public async Task<Product> Get(string id)
        {
            return await _commerceContext.Products.Find(product => product.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Create(Product product)
        {
            await _commerceContext.Products.InsertOneAsync(product);

            return product;
        }

        public async Task Update(string id, Product productIn)
        {
            await _commerceContext.Products.ReplaceOneAsync(product => product.Id == id, productIn);
        }

        public async Task Remove(string id)
        {
            await _commerceContext.Products.DeleteOneAsync(product => product.Id == id);
        }

        public async Task Remove(Product productOut)
        {
            await _commerceContext.Products.DeleteOneAsync(product => product.Id == productOut.Id);
        }
    }
}
