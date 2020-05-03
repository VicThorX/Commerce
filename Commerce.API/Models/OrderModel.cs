using Commerce.Data.Entities;
using System.Collections.Generic;

namespace Commerce.API.Models
{
    public class OrderModel
    {
        public string UserId { get; set; }
        public List<Concept> Concepts { get; set; }
        public decimal Total { get; set; }
    }
}
