﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Commerce.Data.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}