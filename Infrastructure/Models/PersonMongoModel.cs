using Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Models
{
    public class PersonMongoModel : PersonModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        override public int Id { get; set; }
    }
}
