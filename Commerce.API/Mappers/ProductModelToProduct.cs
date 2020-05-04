using Commerce.API.Models;
using Commerce.Data.Entities;
using Commerce.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.API.Mappers
{
    public class ProductModelToProduct : IMapper<ProductModel, Product>
    {
        private readonly ICategoryService _categoryService;

        public ProductModelToProduct(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public void Fill(ProductModel input, Product output)
        {
            output.Name = input.Name;
            output.Category = _categoryService.Get(input.CategoryId).Result;
            output.UnitPrice = input.UnitPrice;
            output.SalePrice = input.SalePrice;
        }

        public Product Map(ProductModel input)
        {
            var output = new Product()
            {
                Name = input.Name,
                Category = _categoryService.Get(input.CategoryId).Result,
                UnitPrice = input.UnitPrice,
                SalePrice = input.SalePrice
            };

            return output;
        }
    }
}
