using Test_Web.Data.Models;
using Test_Web.Models;

namespace Test_Web.Contracts
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductViewModel viewModel);

        Task DeleteProductAsync(int id);

        Task<ProductViewModel> UpdateProductAsync(ProductViewModel viewModel);

        Task<ProductViewModel> GetByIdAsync(int id);

        Task<IEnumerable<ProductViewModel>> GetAllAsync();

    }
}
