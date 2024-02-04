using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public async Task DeleteProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);

            if (product == null)
            {
                throw new ArgumentException("Not Found!");
            }
            else
            {
                context.Products.Remove(product);
            }

            await context.SaveChangesAsync();
        }


        public async Task UpdateProductAsync(ProductViewModel model)
        {

            var prod = await context.Products.FindAsync(model.Id);

            if (prod == null)
            {
                throw new ArgumentException();
            }

            prod.Name = model.Name;
            prod.Amount = model.Amount;
            prod.Price = model.Price;
            prod.Type = model.Type;
            prod.Description = model.Description;

            await context.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var products = await context.Products
                .AsNoTracking()
                .Where(x => x.Name != null && x.Name != string.Empty)
                .Select(x => new ProductViewModel()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Type = x.Type,
                    Amount = x.Amount,
                    Price = x.Price,
                    Id = x.Id
                })
                .ToListAsync();

            return products;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var prod = await context.Products.FindAsync(id);

            if (prod == null)
            {
                throw new ArgumentException("Not found!");
            }

            ProductViewModel productView = new ProductViewModel()
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Type = prod.Type,
                Amount = prod.Amount,
                Price = prod.Price,
            };


            return productView;
        }
    }
}
