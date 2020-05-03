using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Commerce.Data.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public List<Category> SubCategories { get; set; } = new List<Category>();

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("IsRoot")]
        public bool IsRoot { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdateAt")]
        public DateTime UpdateAt { get; set; }
    }
}
