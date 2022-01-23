using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ECommerceAPI.Models;
using System.Collections.Generic;

namespace ECommerceAPI.Models
{
    [BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("product_id")]
        public string product_id { get; set; }

        [BsonElement("product_name")]
        public string product_name { get; set; }

        [BsonElement("product_price")]
        public int product_price { get; set; }

        [BsonElement("product_quantity")]
        public int product_quantity { get; set; }

        [BsonElement("image_path")]
        public string image_path { get; set; }
    }
}

