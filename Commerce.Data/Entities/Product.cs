using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Commerce.Data.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SalePrice { get; set; }
    }
}
