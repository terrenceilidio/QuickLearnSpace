using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace LearnQuickOnline.Models {
    public class Assessment {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<MongoDBRef> Author { get; set; }
        public List<string> Tags { get; set; }
        public DateTime Added { get; set; }
        public DateTime Updated { get; set; }
        public bool IsRemoved { get; set; }
    }
}