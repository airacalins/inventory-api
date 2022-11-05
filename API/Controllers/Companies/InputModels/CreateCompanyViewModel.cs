using Application.Commands.Companies.Dtos;

namespace API.Controllers.Companies.InputModels
{
    public class CreateCompanyViewModel
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public CreateCompanyDto ToDto()
        {
            return new CreateCompanyDto
            {
                ImageUrl = ImageUrl,
                Name = Name
            };
        }
    }
}