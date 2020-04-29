using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Commerce.Data.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("InternalId")]
        public string InternalId { get; set; }

        [BsonElement("Id")]
        [Required]
        public long Id { get; set; }

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

        [BsonElement("HasPurchases")]
        [Required]
        public bool HasPurchases { get; set; }

        [BsonElement("CreatedAt")]
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
