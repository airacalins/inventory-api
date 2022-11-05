using Application.Contexts;
using Domain;

namespace Application.Repositories.CompanyRepositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDataContext _context;
        public CompanyRepository(IDataContext context)
        {
            _context = context;
        }
        public void Add(Company item)
        {
            _context.Companies.Add(item);
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Guid id, Company item)
        {
            throw new NotImplementedException();
        }
    }
}