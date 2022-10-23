using catalog.API.entities;

namespace catalog.API.repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> getproducts();
        Task<Product> getproduct(string id);

        Task<IEnumerable<Product>> getproductbyname(string name);
        Task<IEnumerable<Product>> getproductbycategory(string category);

        Task createproduct(Product product);
        Task<bool> updateproduct(Product product);
        Task<bool> deleteproduct(string id);
    }
}
