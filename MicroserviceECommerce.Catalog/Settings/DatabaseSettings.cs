namespace MicroserviceECommerce.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailsCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
