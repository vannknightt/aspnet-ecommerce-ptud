using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ECommerceAPI.Models;
using System.Collections.Generic;
using System;

namespace ECommerceAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("shop_id")]
        public string shop_id { get; set; }

        [BsonElement("customer_id")]
        public string customer_id { get; set; }

        [BsonElement("shipper_id")]
        public string shipper_id { get; set; }

        [BsonElement("ship_info")]
        public string ship_info { get; set; }

        [BsonElement("status")]
        public int status { get; set; }

        [BsonElement("total")]
        public int total { get; set; }

        [BsonElement("shipper_fee")]
        public int shipper_fee { get; set; }

        [BsonElement("cert_shop")]
        public bool cert_shop { get; set; }

        [BsonElement("cert_cus")]
        public bool cert_cus { get; set; }

        [BsonElement("created_at")]
        public DateTime created_at { get; set; }

        [BsonElement("updated_at")]
        public DateTime updated_at { get; set; }

        [BsonElement("order_detail")]
        public List<OrderDetail> order_detail { get; set; }
    }
}

