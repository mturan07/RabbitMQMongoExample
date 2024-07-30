using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RabbitMQMongoExample.Models
{
    public class MessageModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;
    }
}
