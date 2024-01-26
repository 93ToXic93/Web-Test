using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Test_Web.Contracts;
using Test_Web.Data;
using Test_Web.Data.Models;
using Test_Web.Models;

namespace Test_Web.Services
{
    public class ProductService : IProductService
    {
        private readonly WebDbContext context;

        public ProductService(WebDbContext context)
        {
            this.context = context; 
        }

        public async Task CreateProductAsync(ProductViewModel viewModel)
        {

            Product product = new Product()
            {
                Name = viewModel.Name,
                Amount = viewModel.Amount,
                Type = viewModel.Type,
                Description = viewModel.Description,
                Price = viewModel.Price,
            };

            if (await context.Products.AnyAsync(x => x.Name == product.Name))
            {
                throw new ArgumentException("There is already product with the same name!");
            }

            await context.Products.AddAsync(product);

            await context.SaveChangesAsync();

        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> UpdateProductAsync(ProductViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
