using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnQuickOnline.Services
{
    public class ViewUserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string[] SocialNetworks { get; set; }
        public string[] TopicsOfInterest { get; set; }
        public bool IsActive { get; set; }
        public int NumberOfFollowers { get; set; }
    }
}
