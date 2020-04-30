using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TourOfHeroes.Api.Models 
{
    public class HeroModel 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("id")]
        public long HeroId { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}