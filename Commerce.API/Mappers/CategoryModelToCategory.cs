using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;

namespace Commerce.API.Mappers
{
    public class CategoryModelToCategory : IMapper<CategoryModel, Category>
    {
        private readonly ICategoryService _categoryService;

        public CategoryModelToCategory(ICategoryService categoryService)
        {
            _categoryService = categoryService
        }

        public void Fill(CategoryModel input, Category output)
        {
            output.Name = input.Name;

            foreach (var categoryId in input.SubCategoryIds)
            {
                var category = _categoryService.Get(categoryId).Result;
                output.SubCategories.Add(category);
            }
        }

        public Category Map(CategoryModel input)
        {
            var output = new Category()
            {
                Name = input.Name
            };

            foreach (var categoryId in input.SubCategoryIds)
            {
                var category = _categoryService.Get(categoryId).Result;
                output.SubCategories.Add(category);
            }

            return output;
        }
    }
}
