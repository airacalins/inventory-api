using Domain;

namespace Application.Commands.Companies.Dtos
{
    public class CompanyDto
    {
        public CompanyDto(Company item)
        {
            Id = item.Id;
            ImageUrl = item.ImageUrl;
            Name = item.Name;
        }
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}