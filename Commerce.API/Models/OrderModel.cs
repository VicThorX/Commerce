using Commerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.API.Models
{
    public class OrderModel
    {
        public string UserId { get; set; }
        public List<Concept> Concepts { get; set; }
        public decimal Total { get; set; }
    }
}
