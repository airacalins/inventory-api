using Application.Contexts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.ProductRepositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly IDataContext _context;

        public ProductRepository(IDataContext context) : base(context)
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
            var product = await Get(id);

            product.ImageUrl = item.ImageUrl;
            product.Name = item.Name;
            product.Stocks = item.Stocks;
            product.LowStockLevel = item.LowStockLevel;
            product.Price = item.Price;

            _context.Products.Update(product);

        }
        public async Task Delete(Guid id)
        {
            var product = await Get(id);
            _context.Products.Remove(product);

        }

        public async Task<List<Product>> GetAllByCompanyId(Guid companyId)
        {
            return await _context.Products.Where(product => product.CompanyId == companyId).ToListAsync();
        }

        public async Task<Product> GetCompanyProductById(Guid companyId, Guid productId)
        {
            var product = await _context.Products
            .Where(product => product.CompanyId == companyId)
            .Where(product => product.Id == productId).FirstOrDefaultAsync();

            if (product == null) throw new NullReferenceException();

            return product;
        }

        public async Task SaveChangesAsync()
        {
            await SaveChangeAsync();
        }
    }
}