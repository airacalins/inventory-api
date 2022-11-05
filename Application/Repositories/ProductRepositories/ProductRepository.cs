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
        public async Task<Product> Get(Guid id)
        {
            var product = await _context.Products.Where(product => product.Id == id).FirstOrDefaultAsync();
            if (product == null) throw new NullReferenceException();
            return product;
        }
        public void Add(Product item)
        {
            _context.Products.Add(item);
        }
        public async Task Update(Guid id, Product item)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) throw new NullReferenceException();

            product.ImageUrl = item.ImageUrl;
            product.Name = item.Name;
            product.Stocks = item.Stocks;
            product.LowStockLevel = item.LowStockLevel;
            product.Price = item.Price;

            _context.Products.Update(product);

        }
        public async Task Delete(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) throw new NullReferenceException();
            _context.Products.Remove(product);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}