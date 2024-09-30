using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceECommerce.Catalog.Entities.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }

        //relations
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }

    }
}
