using catalog.API.entities;
using MongoDB.Driver;

namespace catalog.API.data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration cfg)
        {
            var client =new MongoClient(cfg.GetValue<string>("databasesettings:connectionstring"));
            var database = client.GetDatabase(cfg.GetValue<string>("databasesettings:databasename"));

            products = database.GetCollection<Product>(cfg.GetValue<string>("databasesettings:collectionname"));
            CatalogContextSeed.SeedData(products);
        }

        public IMongoCollection<Product> products { get; private set; }
    }
}
