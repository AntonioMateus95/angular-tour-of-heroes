using MongoDB.Bson.Serialization.Attributes;

namespace TourOfHeroes.Api.Models
{
    public class Counter
    {
        [BsonElement("_id")]
        public string TableName { get; set; }

        [BsonElement("sequence_value")]
        public long SequenceValue { get; set; }
    }
}