namespace ECommerceAPI.Models
{
    public class OrderDatabaseSettings : IOrderDatabaseSettings
    {
        public string OrderCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IOrderDatabaseSettings
    {
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}