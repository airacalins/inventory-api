using Application.Contexts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.ProductRepositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context;
        public ProductRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public Task<Product> Get(Guid id)
        {
            throw new NotImplementedException();
        }
        public void Add(Product item)
        {
            _context.Products.Add(item);
        }
        public Task Update(Guid id, Product item)
        {
            throw new NotImplementedException();
        }
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}