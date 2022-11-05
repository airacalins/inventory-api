using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Contexts
{
    public interface IDataContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Company> Companies { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}