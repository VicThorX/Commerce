using Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.API.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalePrice { get; set; }
    }
}
