using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TourOfHeroes.Api.Models 
{
    public class Hero
    {        
        [BsonElement("_id")]
        public long Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}