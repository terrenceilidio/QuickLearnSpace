using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LearnQuickOnline.Models {
    public class Topic {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public List<MongoDBRef> RelatedTopics { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
        public bool IsRemoved { get; set; }
    }
}