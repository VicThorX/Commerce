using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Commerce.Data.Models
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
