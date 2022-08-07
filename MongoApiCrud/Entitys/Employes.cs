using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MongoApiCrud.Entitys
{
    [BsonIgnoreExtraElements]
    public class Employes
    {
        
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string phone { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
