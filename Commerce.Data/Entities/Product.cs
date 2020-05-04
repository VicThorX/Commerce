using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Commerce.Data.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        public Category Category { get; set; }

        [BsonElement("UnitPrice")]
        public decimal UnitPrice { get; set; }

        [BsonElement("SalePrice")]
        public decimal SalePrice { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdateAt")]
        public DateTime UpdateAt { get; set; }
    }
}
