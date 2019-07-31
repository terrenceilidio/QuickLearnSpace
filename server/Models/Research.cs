using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnQuickOnline.Models {
    public class Research {
        [BsonId]
        public List<MongoDBRef> Topics { get; set }
        public List<MongoDBRef> Author { get; set; }
        public List<MongoDBRef> RelatedResearch { get; set; }
        public List<MongoDBRef> RelatedAssessment { get; set; }
        public Datetime DateSubmitted { get; set; }
        public Datetime LastUpdated { get; set; }
    }
}