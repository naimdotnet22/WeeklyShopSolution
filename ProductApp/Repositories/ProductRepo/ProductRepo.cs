using ProductApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.ProductModels;

namespace ProductApp.Repositories.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        #region dependency injection _db
        private readonly ProductDbContext _db;
        public ProductRepo(ProductDbContext db)
        {
            _db = db;
        }
        #endregion

        public async Task<Product> AddOrEdit(Product Product)
        {
            if (Product.ProductId > 0)
            {
                _db.Entry(Product).State = EntityState.Modified;
                await SaveChangesAsync();
                return Product;
            }
            else
            {
                await _db.Products.AddAsync(Product);
                await SaveChangesAsync();
                return Product;
            }
        }

        public async Task<string> DeleteProduct(Product emp)
        {
            _db.Products.Remove(emp);
            await SaveChangesAsync();
            return emp.ProductName + " Deleted Successfully";
        }

        public async Task<Product> FindProduct(int id)
        {
            var emp = await _db.Products.FindAsync(id);
            return emp;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _db.Products.ToListAsync();
        }

        private async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
