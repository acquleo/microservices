using catalog.API.entities;
using MongoDB.Driver;

namespace catalog.API.data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> products { get; }
    }
}
