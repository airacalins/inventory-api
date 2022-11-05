using Application.Commands.Companies.Dtos;

namespace API.Controllers.Companies.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel(CompanyDto item)
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