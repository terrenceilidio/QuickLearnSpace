using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LearnQuickOnline.Models {
    public class User {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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