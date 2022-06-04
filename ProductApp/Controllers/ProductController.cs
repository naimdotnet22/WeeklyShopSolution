using Microsoft.AspNetCore.Mvc;
using ProductApp.Repositories.ProductRepo;
using System.Collections.Generic;
using System.Threading.Tasks;
using zModelEntities.Models.ProductModels;

namespace ProductApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productRepo;

        public ProductController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet("GetProducts")]
        public Task<List<Product>> GetProducts()
        {
            return _productRepo.GetProducts();
        }


        [HttpGet("GetProduct/{id}")]
        public Task<Product> GetProduct(int id)
        {
            return _productRepo.FindProduct(id);
        }


        [HttpPost("AddOrEditProduct")]
        public Task<Product> AddOrEditProduct(Product Product)
        {
            return _productRepo.AddOrEdit(Product);
        }


        [HttpGet("DeleteProduct/{id}")]
        public Task<string> DeleteProduct(int id)
        {
            var emp = _productRepo.FindProduct(id);
            if (emp.Result == null)
            {
                return Task.FromResult("Not Found!");
            }
            return _productRepo.DeleteProduct(emp.Result);
        }
    }
}
