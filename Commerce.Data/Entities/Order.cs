using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Commerce.Data.Entities
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("User")]
        public User User { get; set; }

        [BsonElement("Concepts")]
        public List<Concept> Concepts { get; set; } = new List<Concept>();

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdateAt")]
        public DateTime UpdateAt { get; set; }

        [BsonElement("Total")]
        public decimal Total { get; set; }
    }
}
