using MongoDB.Driver;
using RabbitMQMongoExample.Models;

namespace RabbitMQMongoExample.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<MessageModel> _messagesCollection;

        public MongoDBService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("MessageDB");
            _messagesCollection = database.GetCollection<MessageModel>("Messages");
        }

        public void InsertMessage(MessageModel message)
        {
            _messagesCollection.InsertOne(message);
        }

        public List<MessageModel> GetMessages()
        {
            return _messagesCollection.Find(message => true).ToList();
        }
    }
}
