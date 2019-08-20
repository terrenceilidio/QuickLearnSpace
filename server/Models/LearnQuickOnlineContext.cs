using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using LearnQuickOnline;
using LearnQuickOnline.Configure;

namespace LearnQuickOnline.Models {
    public class LearnQuickOnlineContext {
        private readonly IMongoDatabase _db;
        public LearnQuickOnlineContext (MongoDBConfig config = null) {
            if (config == null) {
                config = new ServerConfig ().MongoDB;
            }
            var client = new MongoClient (config.ConnectionStringTest);
            _db = client.GetDatabase (config.Database);
        }
        public IMongoCollection<User> Users => _db.GetCollection<User> ("User");
        public IMongoCollection<Topic> Topics => _db.GetCollection<Topic> ("Topic");
        public IMongoCollection<Research> Researches => _db.GetCollection<Research> ("Research");
        public IMongoCollection<Assessment> Assessments => _db.GetCollection<Assessment> ("Assessment");
    }
}