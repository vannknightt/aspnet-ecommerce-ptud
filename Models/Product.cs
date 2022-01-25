using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ECommerceAPI.Models;


namespace ECommerceAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Category")]
        public string Category { get; set;}

        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }

        [BsonElement("ShopID")]
        public string shop_id { get; set; }
    }
}

