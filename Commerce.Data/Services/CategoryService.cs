using Commerce.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commerce.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICommerceContext _commerceContext;

        public CategoryService(ICommerceContext commerceContext)
        {
            _commerceContext = commerceContext;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _commerceContext.Categories.Find(category => true).ToListAsync();
        }

        public async Task<Category> Get(string id)
        {
            return await _commerceContext.Categories.Find(category => category.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> Create(Category category)
        {
            await _commerceContext.Categories.InsertOneAsync(category);

            return category;
        }

        public async Task Update(string id, Category categoryIn)
        {
            await _commerceContext.Categories.ReplaceOneAsync(category => category.Id == id, categoryIn);
        }

        public async Task Remove(string id)
        {
            await _commerceContext.Categories.DeleteOneAsync(category => category.Id == id);
        }

        public async Task Remove(Category categoryOut)
        {
            await _commerceContext.Categories.DeleteOneAsync(category => category.Id == categoryOut.Id);
        }
    }
}
