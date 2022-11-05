using Application.Contexts;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.CompanyRepositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDataContext _context;

        public CompanyRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> Get(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null) throw new NullReferenceException();

            return company;
        }
        public void Add(Company item)
        {
            _context.Companies.Add(item);
        }

        public async Task Update(Guid id, Company item)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null) throw new NullReferenceException();

            company.ImageUrl = item.ImageUrl;
            company.Name = item.Name;

            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
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