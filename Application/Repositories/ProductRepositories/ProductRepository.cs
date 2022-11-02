using Application.Contexts;
using Domain;

namespace Application.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Guid id, Product item)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}