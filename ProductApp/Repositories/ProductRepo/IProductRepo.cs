using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.ProductModels;

namespace ProductApp.Repositories.ProductRepo
{
    public interface IProductRepo
    {
        Task<List<Product>> GetProducts();
        Task<Product> FindProduct(int id);
        Task<Product> AddOrEdit(Product Product);
        Task<string> DeleteProduct(Product emp);
    }
}
