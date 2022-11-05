using Application.Commands.Companies.Dtos;

namespace API.Controllers.Companies.InputModels
{
    public class UpdateCompanyViewModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public UpdateCompanyDto ToDto()
        {
            return new UpdateCompanyDto
            {
                ImageUrl = ImageUrl,
                Name = Name,
            };
        }
    }
}