using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Commerce.Data.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Firstname")]
        public string Firstname { get; set; }

        [BsonElement("Lastname")]
        public string Lastname { get; set; }

        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Orders")]
        public List<Order> Orders { get; set; } = new List<Order>();

        [BsonElement("HasPurchases")]
        public bool HasPurchases { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("UpdateAt")]
        public DateTime UpdateAt { get; set; }
    }
}
