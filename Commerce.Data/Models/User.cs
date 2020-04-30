using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Data.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Firstname")]
        [Required]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        [Required]
        public string Lastname { get; set; }

        [BsonElement("EmailAddress")]
        [Required]
        public string EmailAddress { get; set; }

        [BsonElement("Password")]
        [Required]
        public string Password { get; set; }

        [BsonElement("Orders")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [BsonElement("HasPurchases")]
        public bool HasPurchases { get; set; }

        [BsonElement("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdateAt")]
        [Required]
        public DateTime UpdateAt { get; set; }
    }
}
