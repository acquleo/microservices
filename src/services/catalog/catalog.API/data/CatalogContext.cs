using catalog.API.entities;
using MongoDB.Driver;

namespace catalog.API.data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration cfg)
        {
            var client =new MongoClient(cfg.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(cfg.GetValue<string>("DatabaseSettings:databasename"));

            products = database.GetCollection<Product>(cfg.GetValue<string>("DatabaseSettings:collectionname"));
            CatalogContextSeed.SeedData(products);
        }

        public IMongoCollection<Product> products { get; private set; }
    }
}
