using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnQuickOnline.Models {
    public class Research {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public List<MongoDBRef> Author { get; set; }
        public List<MongoDBRef> RelatedResearch { get; set; }
        public List<MongoDBRef> RelatedAssessment { get; set; }
        public DateTime DateSubmitted { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}