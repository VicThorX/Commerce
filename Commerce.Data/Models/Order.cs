using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Data.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public User User { get; set; }

        [BsonElement("Concepts")]
        [Required]
        public List<Concept> Concepts { get; set; }

        [BsonElement("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [BsonElement("Total")]
        [Required]
        public decimal Total { get; set; }
    }
}
