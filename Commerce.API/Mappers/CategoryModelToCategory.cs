using Commerce.API.Models;
using Commerce.Data.Entities;

namespace Commerce.API.Mappers
{
    public class CategoryModelToCategory : IMapper<CategoryModel, Category>
    {
        public void Fill(CategoryModel input, Category output)
        {
            output.Name = input.Name;
            output.SubCategories = input.SubCategories;
        }

        public Category Map(CategoryModel input)
        {
            var category = new Category()
            {
                Name = input.Name,
                SubCategories = input.SubCategories
            };

            return category;
        }
    }
}
