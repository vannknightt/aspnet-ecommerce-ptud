namespace ECommerceAPI.Models
{
    public class ProductDatabaseSettings : IProductDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IProductDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}