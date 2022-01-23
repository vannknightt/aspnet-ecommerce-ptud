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
        public string product_id { get; set; }

        [BsonElement("Name")]
        public string product_name { get; set; }

        [BsonElement("Price")]
        public decimal product_price { get; set; }

        [BsonElement("Category")]
        public string product_category { get; set;}

        [BsonElement("ImagePath")]
        public string image_path { get; set; }

        [BsonElement("ShopID")]
        public string shop_id { get; set; }
    }
}

