using Commerce.Data.Entities;
using System.Collections.Generic;

namespace Commerce.API.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public List<Category> SubCategories { get; set; }
    }
}
