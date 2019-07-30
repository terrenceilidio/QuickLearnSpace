using LearnQuickOnline;
using LearnQuickOnline.Configure;
using MongoDB.Driver;
using System;

namespace LearnQuickOnline.Models
{
    public class LearnQuickOnlineContext
    {
        private readonly IMongoDatabase _db;
        public LearnQuickOnlineContext(MongoDBConfig config = null)
        {
            if(config == null){
                config = new ServerConfig().MongoDB;
            }
            var client = new MongoClient(config.ConnectionStringTest);
            _db = client.GetDatabase(config.Database);
        }
        public IMongoCollection<User> users =>  _db.GetCollection<User>("Users");
    }
}