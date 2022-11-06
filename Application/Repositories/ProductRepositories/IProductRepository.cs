using Domain;

namespace Application.Repositories.ProductRepositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetAllByCompanyId(Guid companyId);
        Task<Product> GetCompanyProductById(Guid companyId, Guid productId);
    }
}