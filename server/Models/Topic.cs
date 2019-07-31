using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnQuickOnline.Models {
    public class Topic {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public List<MongoDBRef> RelatedTopics { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
        public bool IsRemoved { get; set; }
    }
}