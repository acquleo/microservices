using MongoDB.Bson.Serialization.Attributes;

namespace catalog.API.entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Category { get; set; }

        [BsonElement]
        public string Summary { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public string ImageFile { get; set; }

        [BsonElement]
        public decimal Price { get; set; }

    }
}
