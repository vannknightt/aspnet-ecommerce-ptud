using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ECommerceAPI.Models;
using System.Collections.Generic;

namespace ECommerceAPI.Models
{
    [BsonIgnoreExtraElements]
    public class OrderDetail
    {
        [BsonElement("ProductID")]
        public string ProductID { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public int Price { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }

        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }
    }
}

