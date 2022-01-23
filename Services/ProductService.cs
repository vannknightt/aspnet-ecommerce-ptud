using ECommerceAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceAPI.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IProductDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _products = database.GetCollection<Product>(settings.ProductCollectionName);
        }

        public List<Product> Get() =>
            _products.Find(product => true).ToList();

        public Product Get(string id) =>
            _products.Find<Product>(product => product.product_id == id).FirstOrDefault();

        public Product Create(Product product)
        {
            _products.InsertOne(product);
            return product;
        }

        public void Update(string id, Product productIn) =>
            _products.ReplaceOne(product => product.product_id == id, productIn);

        public void Remove(Product productIn) =>
            _products.DeleteOne(product => product.product_id == productIn.product_id);

        public void Remove(string id) =>
            _products.DeleteOne(product => product.product_id == id);
    }
}