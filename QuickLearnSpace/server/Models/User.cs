using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnQuickOnline.Models
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}