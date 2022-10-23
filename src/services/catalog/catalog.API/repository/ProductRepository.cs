using catalog.API.data;
using catalog.API.entities;
using MongoDB.Driver;

namespace catalog.API.repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context;
        }


        public Task createproduct(Product product)
        {
            return _context.products.InsertOneAsync(product);
        }

        public async Task<bool> deleteproduct(string id)
        {
            FilterDefinition < Product > filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var deleteresult = await _context.products.DeleteOneAsync(filter);

            return deleteresult.IsAcknowledged && deleteresult.DeletedCount > 0;
        }

        public async Task<Product> getproduct(string id)
        {
            return await _context.products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public  async Task<IEnumerable<Product>> getproductbycategory(string category)
        {
            return await _context.products.Find(p => p.Category==category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> getproductbyname(string name)
        {
            return await _context.products.Find(p => p.Name==name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> getproducts()
        {
            return _context.products.Find(p=>true).ToList();
        }

        public async Task<bool> updateproduct(Product product)
        {
            var updateresult = await _context.products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updateresult.IsAcknowledged && updateresult.ModifiedCount > 0;
        }
    }
}