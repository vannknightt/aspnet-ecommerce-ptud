using ECommerceAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace ECommerceAPI.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IOrderDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orders = database.GetCollection<Order>(settings.OrderCollectionName);
        }

        public List<Order> Get() =>
            _orders.Find(order => true).ToList();

        public Order Get(string id) =>
            _orders.Find<Order>(order => order.id == id).FirstOrDefault();

        public Order Create(Order order)
        {
            try
            {
                _orders.InsertOne(order);
            }
            catch (MongoWriteException e)
            {
                Debug.WriteLine(e.Message);
            }
            return order;
        }

        public void Update(string id, Order orderIn) =>
            _orders.ReplaceOne(order => order.id == id, orderIn);

        public void Remove(Order orderIn) =>
            _orders.DeleteOne(order => order.id == orderIn.id);

        public void Remove(string id) =>
            _orders.DeleteOne(order => order.id == id);
    }
}